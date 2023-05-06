using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cosmonaut : MonoBehaviour
{
    Rigidbody rb;
    float move;

    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * move * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        Debug.Log(rb.velocity.magnitude);
    }

    public void Move(InputAction.CallbackContext context)
    {
        move = context.ReadValue<float>();
    }
}
