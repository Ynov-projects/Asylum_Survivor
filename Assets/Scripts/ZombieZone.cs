using UnityEngine;

public class ZombieZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.GetChild(0).GetComponent<ZombieScript>().changeTooClose(true);
            PlayerMentalHealth.Instance.ZombieClose++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transform.GetChild(0).GetComponent<ZombieScript>().changeTooClose(false);
            PlayerMentalHealth.Instance.ZombieClose--;
        }
    }
}
