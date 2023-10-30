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
    public bool isLocked;

    void Start()
    {
        inReach = false;
        door.SetBool("open", isOpen);
        door.SetBool("closed", !isOpen);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            if (!isLocked)
                openText.SetActive(true);
            else lockedText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            if(isLocked == false)
                openText.SetActive(false);
            else lockedText.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Player"))
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
            if(door.GetBool("closed") && !isLocked)
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
        door.SetBool("open", true);
        door.SetBool("closed", false);
        isOpen = true;

    }

    public void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
        isOpen = false;
    }

}
