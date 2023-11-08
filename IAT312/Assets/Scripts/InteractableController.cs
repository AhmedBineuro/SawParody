using UnityEngine;
using UnityEngine.Events;

public class InteractableController : MonoBehaviour
{
    public UnityEvent Function;
    // This method would be called when the object is interacted with
    public void Interact()
    {
        // Define what happens when the object is interacted with
        Function.Invoke();
    }
}
