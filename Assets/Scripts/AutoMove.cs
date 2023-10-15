using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float torqueForce = 5.0f; // Set the force with which to push it with
    public float torqueScaleFactor = 0.2f;
    private float currentSpeed;
    private Rigidbody rb;
    private float objectLength;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = torqueForce;
    }
    void Update()
    {
        //rb.velocity = new Vector3(currentSpeed, rb.velocity.y, 0); // Move the object to the right
        // Apply a continuous torque to keep the capsule rolling

        // Check if the Renderer component exists
        objectLength = transform.localScale.y;
        float balancedForce = torqueForce - (torqueScaleFactor * objectLength);
        Vector3 force = new Vector3(0, 0, -balancedForce);
        Debug.Log("current force: " + force + "objectLength: " + objectLength);
        rb.AddTorque(force);
    }

    public void decreaseSpeed(float decreaseSpeed)
    {
        currentSpeed = torqueForce - decreaseSpeed;
    }
}

