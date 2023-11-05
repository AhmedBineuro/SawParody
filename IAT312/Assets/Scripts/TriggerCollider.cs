using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerCollider : MonoBehaviour
{
    public UnityEvent eventlist;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Invoke events
            eventlist.Invoke();
        }
    }
}
