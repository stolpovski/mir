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
    AudioSource sfx;
    
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(forward * force * Vector3.forward, ForceMode.Impulse);
        rb.AddRelativeForce(up * force * Vector3.up, ForceMode.Impulse);
        rb.AddRelativeForce(side * force * Vector3.right, ForceMode.Impulse);

        rb.AddRelativeTorque(pitch * torque * Vector3.left, ForceMode.Impulse);
        rb.AddRelativeTorque(yaw * torque * Vector3.up, ForceMode.Impulse);
        rb.AddRelativeTorque(roll * torque * Vector3.back, ForceMode.Impulse);
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

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(rb.velocity.magnitude);
        
        if (!sfx.isPlaying)
        {
            sfx.volume = rb.velocity.magnitude;
            sfx.Play();
        }
            
    }
}
