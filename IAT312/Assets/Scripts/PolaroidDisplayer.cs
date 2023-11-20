using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PolaroidDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CharacterController player = null;
    [SerializeField] private InputBehavior inputBehavior = null;
    [SerializeField] private GameObject image;
    private Boolean isOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && isOpen)
        {
            hideImage();
        }   
    }
    public void DisablePlayer(bool disable)
    {
        if (player != null)
        {
            player.enabled = !disable;
        }
        else
        {
            Debug.LogError("You may want to add the player object into the inspector slot of the Disable Manager - Or change this if you're using a different controller");
        }
        if (inputBehavior != null)
        {
            inputBehavior.look.MoveCam = !disable;
        }
        else
        {
            Debug.LogError("Add the input behaviour script (Usually found on the Player) to the Disable Manager");
        }
    }
    public void showImage()
    {
        isOpen= true;
        DisablePlayer(true);
        image.SetActive(true);
    }
    public void hideImage()
    {
        DisablePlayer(false);
        isOpen = false;
        image.SetActive(false);
    }
}
