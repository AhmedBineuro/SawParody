using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static  BackgroundMusic instance = null;

    void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // Set this instance as the singleton
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object between scene changes
        }
        else
        {
            // Destroy any duplicates
            Destroy(gameObject);
        }
    }
}