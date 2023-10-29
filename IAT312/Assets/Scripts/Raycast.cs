using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to include UnityEngine.UI

public class Raycast : MonoBehaviour
{
    [Header("Raycast Features")]
    [SerializeField] private float reach_length;
    private Camera main_camera;

    [Header("Crosshair")]
    [SerializeField] private Image crosshair;

    [Header("Input Key")]
    [SerializeField] private KeyCode interactKey;

    // Start is called before the first frame update
    void Start()
    {
        main_camera = GetComponent<Camera>(); // Change getComponent to GetComponent
    }

    // Update is called once per frame
    private void Update()
    {
        if (Physics.Raycast(main_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, reach_length))
        {
            var readableItem = hit.collider.GetComponent<InteractableController>(); // Change getComponent to GetComponent
            if (readableItem != null)
            {
                // show the hud and switch the control scheme 
            }
            else
            {
                // Clear readable Item
            }
        }
        else
        {
            // Clear readable Item
        }

        /*if(*//*Linked InteractableController*//*)
        {
            if (Input.GetKeyDown(interactKey))
            {

            }
        }*/
    }

    void HighlightCrosshair(bool on)
    {
    }
}
