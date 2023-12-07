using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private Animator animator;

    private int _numberOfCollidingItems = 0;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 CurrentSpeed = _rb.velocity;
        Vector3 tempSpeed = CurrentSpeed;

        // Rotation
        if (Mathf.Abs(horizontalMovement) > 0.3f)
        {
            transform.Rotate(new Vector3(0, horizontalMovement * _rotationSpeed * Time.deltaTime, 0));
        }
        // Avancer / Reculer
        if (Mathf.Abs(verticalMovement) > 0.3f)
        {
            Debug.Log(Input.GetKey(KeyCode.LeftShift));
            int running = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
            tempSpeed = transform.forward * verticalMovement * running * _speed;
        }
        tempSpeed.y = CurrentSpeed.y;
        _rb.velocity = Vector3.Lerp(_rb.velocity, tempSpeed, Time.deltaTime);

        animator.SetFloat("Speed", _rb.velocity.magnitude);

        if (Input.GetKeyDown(KeyCode.Space) && _numberOfCollidingItems > 0) _rb.AddForce(new Vector3(0, _jumpForce, 0));

        if (_rb.velocity.y < -1) _rb.AddForce(Physics.gravity * Time.deltaTime * 50);
    }

    private void OnTriggerEnter(Collider other)
    {
        _numberOfCollidingItems++;
    }

    private void OnTriggerExit(Collider other)
    {
        _numberOfCollidingItems--;
    }
}
