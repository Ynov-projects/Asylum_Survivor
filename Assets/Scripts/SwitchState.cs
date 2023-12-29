using System.Collections;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    private bool someoneHere;
    private bool isOpened;

    [SerializeField] private Animator animator;
    [SerializeField] private bool isLightSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") someoneHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") someoneHere = false;
    }

    private void Update()
    {
        if (someoneHere)
        {
            if(Input.GetKeyDown(KeyCode.E) && (isLightSwitch ? !isOpened : true))
            {
                if (isLightSwitch) StartCoroutine(SwitchActivated());
                else SwitchingState();
            }
        }
    }

    IEnumerator SwitchActivated()
    {
        SwitchingState();
        yield return new WaitForSeconds(30);
        SwitchingState();
    }

    private void SwitchingState()
    {
        isOpened = !isOpened;
        animator.SetBool("opening", !animator.GetBool("opening"));
        if (isLightSwitch) SwitchLights.Instance.Switch();
    }
}
