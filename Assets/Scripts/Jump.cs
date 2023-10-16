using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5.0f;
    private bool isGrounded = false;

    private Rigidbody rb;

    Subscription<AirEvent> airEventSubscription;

    private void Start()
    {
        airEventSubscription = EventBus.Subscribe<AirEvent>(_OnChange);
        rb = GetComponent<Rigidbody>();
    }

    void _OnChange(AirEvent e)
    {
        isGrounded = e.isGrounded;
        Debug.Log("isGrounded: " + isGrounded);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Tried to jump");
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }
}
