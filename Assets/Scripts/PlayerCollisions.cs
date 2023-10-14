using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Rigidbody rb;
    private AutoMove movement;

    Subscription<DeathEvent> deathEventSub;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<AutoMove>();
        deathEventSub = EventBus.Subscribe<DeathEvent>(_OnPlayerDeath);
    }

    private void OnCollisionEnter(Collision other)
    {
        // if the object component isn't the ground it's not an obstacle
        if (other.gameObject.GetComponent<Ground>() != null)
        {
            EventBus.Publish<AirEvent>(new AirEvent(isGrounded: true));
        }
            
    }

    private void OnCollisionExit(Collision other)
    {
        EventBus.Publish<AirEvent>(new AirEvent(isGrounded: false));
    }

    void _OnPlayerDeath(DeathEvent e)
    {
        rb.velocity = Vector3.zero;
        movement.enabled = false;
    }
}

public class AirEvent
{
    public bool isGrounded = true;
    public AirEvent(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

}

