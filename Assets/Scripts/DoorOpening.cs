using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    private bool someoneHere;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        someoneHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        someoneHere = false;
    }

    private void Update()
    {
        if (someoneHere)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("opened", !animator.GetBool("opened"));
            }
        }
    }
}
