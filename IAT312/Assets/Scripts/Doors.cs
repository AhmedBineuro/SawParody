using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;
    public GameObject openText;

    public bool inReach;

    void Start()
    {
        inReach = false;
        door.SetBool("open", false);
        door.SetBool("closed", true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            if(door.GetBool("closed"))
                DoorOpens();
            else
                DoorCloses();
        }
    }
    public void DoorOpens ()
    {
        door.SetBool("open", true);
        door.SetBool("closed", false);

    }

    public void DoorCloses()
    {
        door.SetBool("open", false);
        door.SetBool("closed", true);
    }

}