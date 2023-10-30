using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class DialogueSegment 
    {
        public string SubjectText;
        [TextArea]
        public string DialogueToPrint;
        public bool Skippable;
        [Range(1f, 25f)]
        public float LettersPerSecond;
    }

    [SerializeField] private DialogueSegment[] DialogueSegments;
    [Space]
    [SerializeField] private TMP_Text SubjectText;
    [SerializeField] private TMP_Text BodyText;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private Doors[] doors;
    private bool PlayingDialogue;
    private bool Skip;
    private int CurrentSegmentIndex;
    private GameObject parentGameObject; // Reference to the parent GameObject
    private DialogueSegment currentDialogueSegment;
    // Method to set the parent GameObject

    public void Start()
    {
        HideDialogueCanvas();
    }
    
    public void SetParentGameObject(GameObject parent)
    {
        parentGameObject = parent;
    }
    public void SetDialogueSegment(int index)
    {
        if (index >= 0 && index < DialogueSegments.Length)
        {
            currentDialogueSegment = DialogueSegments[index];
        }
        else
        {
            Debug.LogError("Invalid dialogue segment index: " + index);
        }
    }

    private void ShowDialogueCanvas()
    {
        dialogueCanvas.gameObject.SetActive(true); // Show the entire Canvas GameObject
    }

    public void StartDialogue()
    {
        // Check if a valid dialogue segment is set before starting the dialogue
        if (currentDialogueSegment != null)
        {
            // Start displaying the dialogue segment
            for(int i=0;i<doors.Length;i++)
            {
                doors[i].LockDoor();
            }
            StartCoroutine(PlayDialogue(currentDialogueSegment));
        }
        else
        {
            Debug.LogError("No valid dialogue segment set.");
        }
    }

    private void HideDialogueCanvasWithDelay()
    {
        // Hide the canvas and the parent GameObject after a delay of 2 seconds
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].UnlockDoor();
        }
        Invoke("HideDialogueCanvas", 1f);
    }

    private void HideDialogueCanvas()
    {
        dialogueCanvas.gameObject.SetActive(false); // Hide the entire Canvas GameObject
    }

    private void Update()
    {
        // Handle skipping or closing the dialogue here if needed
    }

    private IEnumerator PlayDialogue(DialogueSegment segment)
    {
        ShowDialogueCanvas();

        PlayingDialogue = true;
        BodyText.SetText(string.Empty);
        SubjectText.SetText(segment.SubjectText);

        float delay = 1f / segment.LettersPerSecond;
        for (int i = 0; i < segment.DialogueToPrint.Length; i++)
        {
            if (Skip)
            {
                BodyText.SetText(segment.DialogueToPrint);
                Skip = false;
                break;
            }

            string chunkToAdd = string.Empty;
            chunkToAdd += segment.DialogueToPrint[i];
            if (segment.DialogueToPrint[i] == ' ' && i < segment.DialogueToPrint.Length - 1)
            {
                chunkToAdd = segment.DialogueToPrint.Substring(i, 2);
                i++;
            }

            BodyText.text += chunkToAdd;
            yield return new WaitForSeconds(delay);
        }

        PlayingDialogue = false;

        // Move to the next segment if available
        CurrentSegmentIndex++;
        if (CurrentSegmentIndex < DialogueSegments.Length)
        {
            // Start the next segment
            StartCoroutine(PlayDialogue(DialogueSegments[CurrentSegmentIndex]));
        }
        else
        {
            // All segments are displayed, hide the text and the parent GameObject
            HideDialogueCanvasWithDelay();
            gameObject.SetActive(false); // Hide the DialogueManager GameObject
            if (parentGameObject != null)
            {
                parentGameObject.SetActive(false); // Hide the parent GameObject
            }
        }
    }
}
