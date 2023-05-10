using UnityEngine;
using UnityEngine.InputSystem;

public class Cosmonaut : MonoBehaviour
{
    Rigidbody rb;
    
    float forward;
    float up;
    float side;

    float pitch;
    float yaw;
    float roll;

    public float force = 1f;
    public float torque = 0.001f;
    
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * forward * force, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.up * up * force, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.right * side * force, ForceMode.Impulse);

        rb.AddRelativeTorque(Vector3.left * pitch * torque, ForceMode.Impulse);
        rb.AddRelativeTorque(Vector3.up * yaw * torque, ForceMode.Impulse);
        rb.AddRelativeTorque(Vector3.back * roll * torque, ForceMode.Impulse);
    }

    private void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        //Debug.Log(rb.angularVelocity.magnitude);
    }

    public void Forward(InputAction.CallbackContext context)
    {
        forward = context.ReadValue<float>();
    }

    public void Up(InputAction.CallbackContext context)
    {
        up = context.ReadValue<float>();
    }

    public void Side(InputAction.CallbackContext context)
    {
        side = context.ReadValue<float>();
    }

    public void Pitch(InputAction.CallbackContext context)
    {
        pitch = context.ReadValue<float>();
    }

    public void Yaw(InputAction.CallbackContext context)
    {
        yaw = context.ReadValue<float>();
    }

    public void Roll(InputAction.CallbackContext context)
    {
        roll = context.ReadValue<float>();
    }
}
