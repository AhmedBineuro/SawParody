using UnityEngine;
using UnityEngine.Events;

public class InteractableController : MonoBehaviour
{
    public UnityEvent Function;
    public GameObject parentObject; //Used to debug
    // This method would be called when the object is interacted with
    public void Interact()
    {
        // Define what happens when the object is interacted with
        Function.Invoke();
        Debug.Log("Interacted with"+parentObject.name);
    }
}
