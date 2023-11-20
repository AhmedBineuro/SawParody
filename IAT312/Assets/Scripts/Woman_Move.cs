// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class Woman_Move : MonoBehaviour
// {
//     public NavMeshAgent woman;
//     public Transform targetObj;
//     private float fixedYPosition = -0.08000183f;
//     public Animator animator;
//     private bool triggerActivated = false;
//     private bool IsMoving = false;

//     // Start is called before the first frame update
//     void Start()
//     {
//         animator = GetComponent<Animator>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (triggerActivated)
//         {
//             // woman.SetDestination(targetObj.position);

//             // Vector3 newPosition = new Vector3(transform.position.x, fixedYPosition, transform.position.z);
//             // transform.position = newPosition;
//                         // Set destination with the same y position
//             Vector3 targetPosition = new Vector3(targetObj.position.x, fixedYPosition, targetObj.position.z);
//             woman.SetDestination(targetPosition);

//             // Keep the y position fixed
//             Vector3 newPosition = new Vector3(transform.position.x, fixedYPosition, transform.position.z);
//             transform.position = newPosition;

//             if (woman.remainingDistance > woman.stoppingDistance)
//             {
//                 IsMoving = true;
//             }
//             else
//             {
//                 IsMoving = false;
//             }
//             animator.SetBool("IsMoving", IsMoving);
//         }
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (!triggerActivated && other.CompareTag("Player"))
//         {
//             // Set the trigger as activated
//             triggerActivated = true;

//             // Disable the trigger box collider to prevent further triggers
//             GetComponent<Collider>().enabled = false;
//         }
//     }
// }
using UnityEngine;
using UnityEngine.AI;

public class Woman_Move : MonoBehaviour
{
    public NavMeshAgent woman;
    public Transform targetObj;
    private float fixedYPosition = -0.08000183f;
    public Animator animator;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        woman.enabled = false; // Disable NavMeshAgent initially
    }

    // Update is called once per frame
    void Update()
    {
        // if (isMoving)
        // {
            woman.SetDestination(targetObj.position);

            // Keep the y position fixed
            Vector3 newPosition = new Vector3(transform.position.x, fixedYPosition, transform.position.z);
            transform.position = newPosition;

            // Check if the woman is moving
            if (woman.remainingDistance > woman.stoppingDistance)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            // Set the animator parameter based on whether the woman is moving
            animator.SetBool("IsMoving", isMoving);
       // }
    }

    public void StartMoving()
    {
        // Enable the NavMeshAgent to start moving
        woman.enabled = true;
        //isMoving = true;
    }
}
