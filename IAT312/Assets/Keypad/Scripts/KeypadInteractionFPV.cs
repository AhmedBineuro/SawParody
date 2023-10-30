using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavKeypad { 
public class KeypadInteractionFPV : MonoBehaviour
{
    private Camera cam;
    public GameObject openText;
    private void Awake() => cam = Camera.main;
    private void Update()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            if (Input.GetButtonDown("Interact"))
            {
                openText.SetActive(true);
                if (hit.collider.TryGetComponent(out KeypadButton keypadButton))
                {
                    keypadButton.PressButton();
                }
            }
            else openText.SetActive(false);
        }
    }
}
}