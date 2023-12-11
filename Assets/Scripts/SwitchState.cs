using UnityEngine;

public class SwitchState : MonoBehaviour
{
    private bool someoneHere;
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
            if(Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("opening", !animator.GetBool("opening"));
                if (isLightSwitch) SwitchLights.Instance.Switch();
            }
        }
    }
}
