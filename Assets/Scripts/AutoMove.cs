using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float regularSpeed = 5.0f; // Set the force with which to push it with
    private float currentSpeed;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = regularSpeed;
    }
    void Update()
    {
        rb.velocity = new Vector3(currentSpeed, rb.velocity.y, 0); // Move the object to the right
    }

    public void decreaseSpeed(float decreaseSpeed)
    {
        currentSpeed = regularSpeed - decreaseSpeed;
    }
}

