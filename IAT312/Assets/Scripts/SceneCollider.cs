using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCollider : MonoBehaviour
{
    public string sceneToLoad;  // Name of the scene to load
    public FirstPersonCamera player;

    void Start()
    {
        // Make sure to mark the box collider as trigger
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Load the new scene
            player.MoveCam = false;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

