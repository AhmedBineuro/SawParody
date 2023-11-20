using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include UnityEngine.UI

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float reach_length;
    private Camera main_camera;

    [Header("HUD Element")]
    [SerializeField] private GameObject canvas;

    [Header("Interact Key Name")]
    [SerializeField] private string interactKey;
    void Start()
    {
        main_camera = Camera.main; // This assigns the main camera from the scene to the variable.
    }

    // Update is called once per frame

    private void Update()
    {
        LayerMask mask = ~LayerMask.GetMask("Ignore Raycast");
        if (Physics.Raycast(main_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), main_camera.transform.forward, out RaycastHit hit, reach_length,mask))
        {
            var readableItem = hit.collider.GetComponent<InteractableController>(); // Change getComponent to GetComponent
            if (readableItem != null)
            {
                canvas.SetActive(true);
                if (Input.GetButton(interactKey))
                { 
                    readableItem.Interact(); 
                }
            }
            else
            {
                // Clear readable Item
                canvas.SetActive(false);
            }
        }
        else
        {
            // Clear readable Item
            canvas.SetActive(false);
        }
    }
}
