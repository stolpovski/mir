using UnityEngine;
using UnityEngine.InputSystem;

public class Cosmonaut : MonoBehaviour
{
    Rigidbody rb;
    
    float thrust;
    float yaw;
    float lift;

    public float force = 1f;
    public float torque = 0.001f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * thrust * force, ForceMode.Impulse);
        rb.AddRelativeForce(Vector3.up * lift * force, ForceMode.Impulse);
        rb.AddRelativeTorque(Vector3.up * yaw * torque, ForceMode.Impulse);
    }

    private void Update()
    {
        //Debug.Log(rb.velocity.magnitude);
        Debug.Log(rb.angularVelocity.magnitude);
    }

    public void Thrust(InputAction.CallbackContext context)
    {
        thrust = context.ReadValue<float>();
    }

    public void Lift(InputAction.CallbackContext context)
    {
        lift = context.ReadValue<float>();
    }

    public void Yaw(InputAction.CallbackContext context)
    {
        yaw = context.ReadValue<float>();
    }
}
