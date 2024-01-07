using UnityEngine;

public class ZombieZone : MonoBehaviour
{
    [SerializeField] private AudioSource clip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            clip.Play();
            transform.GetChild(0).GetComponent<ZombieScript>().changeTooClose(true);
            PlayerMentalHealth.Instance.ZombieClose++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            clip.Stop();
            transform.GetChild(0).GetComponent<ZombieScript>().changeTooClose(false);
            PlayerMentalHealth.Instance.ZombieClose--;
        }
    }
}
