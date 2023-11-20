using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    public Woman_Move womanController;

    private bool triggerActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!triggerActivated && other.CompareTag("Player"))
        {
            // Set the trigger as activated
            triggerActivated = true;

            // Start the woman's movement
            womanController.StartMoving();

            // Disable the trigger box collider to prevent further triggers
            GetComponent<Collider>().enabled = false;
        }
    }
}