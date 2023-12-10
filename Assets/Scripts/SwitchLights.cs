using System.Collections.Generic;
using UnityEngine;

public class SwitchLights : MonoBehaviour
{
    private List<Light> lights = new List<Light>();
    private bool playerHere;

    [SerializeField] private Animator animator;

    private void Start()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Light");
        foreach(GameObject go in gameObjects) lights.Add(go.GetComponent<Light>());
    }

    private void Update()
    {
        if (playerHere)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("opening", !animator.GetBool("opening"));
                foreach(Light light in lights)
                {
                    light.enabled = !light.enabled;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") playerHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") playerHere = false;
    }
}
