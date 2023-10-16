using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCollisions : MonoBehaviour
{
    public ParticleSystem hitParticles;

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
            hitParticles.transform.position = other.contacts[0].point;
            // If you want to set the emission velocity based on the player's velocity at the point of contact:
            var main = hitParticles.main;
            main.startSpeed = rb.velocity.magnitude;
            hitParticles.Play();
            EventBus.Publish<AirEvent>(new AirEvent(isGrounded: true));
            // Move the Particle System to the player's position (or collision point)
            Vector3 emitPosition = other.contacts[0].point;
            emitPosition.z -= 0.5f;  // Decrease the z coordinate by 'someValue'
            hitParticles.transform.position = emitPosition;


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

