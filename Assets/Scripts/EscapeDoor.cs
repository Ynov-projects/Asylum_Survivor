using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeDoor : MonoBehaviour
{
    private bool someoneHere;
    [SerializeField] private Item key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") someoneHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") someoneHere = false;
    }

    private void Update()
    {
        if (someoneHere)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (key.Quantity == 1) GameManager.Instance.Win();
            }
        }
    }
}
