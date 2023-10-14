using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        EventBus.Publish<DeathEvent>(new DeathEvent());
    }
}

public class DeathEvent
{
    public DeathEvent()
    {
    }
}