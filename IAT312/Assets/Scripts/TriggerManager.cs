using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public int dialogueSegmentIndex = 0; // Index of the dialogue segment to be displayed

    private bool hasBeenActivated = false; // Flag to track if the trigger has been activated

    private void OnTriggerEnter(Collider other)
    {
        if (!hasBeenActivated && other.CompareTag("Player"))
        {
            // Set the specific dialogue segment and start the dialogue
            if (!dialogueManager.playing)
            {       
                dialogueManager.SetDialogueSegment(dialogueSegmentIndex);
                dialogueManager.StartDialogue();
                hasBeenActivated = true; // Mark the trigger as activated
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the collider to prevent further triggering
            GetComponent<Collider>().enabled = false;
        }
    }
}