using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject lockedText;
    private bool inReach;
    public bool isOpen = false;
    public bool isLocked=false;
    public bool autoClose = true;

    void Start()
    {
        inReach = false;
        door.SetBool("open", isOpen);
        door.SetBool("closed", !isOpen);
    }

    void OnTriggerEnter(Collider other)
    {
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            lockedText.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player") && autoClose)
        {
            isLocked = true;
            Invoke("DoorCloses", 20f);
            DoorCloses();
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            if (door.GetBool("closed") && !isLocked)
                DoorOpens();
            else
                DoorCloses();
        }
    }

    public void LockDoor()
    {
        isLocked = true;
    }
    public void UnlockDoor()
    {
        isLocked = false;
    }
    public void DoorOpens ()
    {
        if (!isLocked)
        {
            door.SetBool("open", true);
            door.SetBool("closed", false);
            isOpen = true;
            isLocked = false;
        }
    }

    public void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
        isOpen = false;
    }
    public void setAutoCLose(bool autoClose)
    {
        this.autoClose = autoClose;
    }

}
