using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _horizontalMovement = 2f;
    [SerializeField] private float _verticalMovement = 2f;

    private float yaw;
    private float pitch;

    private void Update()
    {
        float tempYaw = yaw + _horizontalMovement * Input.GetAxis("Mouse X");
        float tempPitch = pitch - _verticalMovement * Input.GetAxis("Mouse Y");
        yaw = tempYaw;
        pitch = tempPitch > -15 || tempPitch < 50 ? tempPitch : pitch;
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}
