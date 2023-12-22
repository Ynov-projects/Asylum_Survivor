using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Animator _animator;

    [SerializeField] private Rigidbody rb;

    private bool tooClose;
    private Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }

    void Update()
    {
        // Permet d'avoir un mob qui retourne au point de départ si le personnage sort de sa zone
        GetComponent<NavMeshAgent>().SetDestination(tooClose ? _playerTransform.position : initialPos);
        Debug.Log(tooClose);
        _animator.SetFloat("walking", tooClose ? rb.velocity.normalized.magnitude : 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.Instance.Death();
    }

    public void changeTooClose(bool closeOrNot)
    {
        tooClose = closeOrNot;
    }
}
