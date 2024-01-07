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
        if (Mathf.Abs(horizontalMovement) > 0.3f || Mathf.Abs(verticalMovement) > 0.3f)
        {
            float running = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;
            tempSpeed = transform.forward * verticalMovement * running * _speed + transform.right * horizontalMovement * _speed;
        }
        // Avancer / Reculer
        if (Mathf.Abs(verticalMovement) > 0.01f)
        {
        }

        //float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        //float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        //_rb.velocity = new Vector3(xMove, _rb.velocity.y, zMove) * _speed; // Creates velocity in direction of value equal to keypress (WASD). rb.velocity.y deals with falling + jumping by setting velocity to y. 


        tempSpeed.y = CurrentSpeed.y;
        _rb.velocity = tempSpeed;

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
