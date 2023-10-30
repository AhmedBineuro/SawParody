using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // This method is called when the trigger event occurs
    public FirstPersonCamera f;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (or any other desired object)
        if (other.CompareTag("Player"))
        {
            // Call the PlayWireTask method to switch the scene
            if (SceneManager.GetActiveScene().name=="TutorialRoom")
            {
                f.MoveCam = false;
                SceneManager.LoadScene("WireGameScene");
            }
        }
    }
    public void Exit() 
    {
        f.MoveCam = true;
        SceneManager.LoadScene("GameScene");
    }
}