using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayAudioAndSwitchScene : MonoBehaviour
{
    public string sceneToSwitchTo;
    public AudioSource audioSource;
    public AudioClip clipToPlay;

    void Start()
    {
        // Attach this GameObject to the root so it won't be destroyed when a new scene loads
        DontDestroyOnLoad(gameObject);
    }

    public void PlayAudioAndSwitch()
    {
        // Play the audio
        /*audioSource.clip = clipToPlay;*/
        audioSource.Play();
        // Start the coroutine to switch scenes
        StartCoroutine(SwitchSceneAfterDelay());
    }
    private IEnumerator SwitchSceneAfterDelay()
    {
        // Wait for a short moment
        yield return new WaitForSeconds(1f);

        // Switch the scene
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}
