using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public Transform[] backgroundObjects;
    public Transform player;
    Subscription<RestartEvent> RestartSubscription;

    private int currentIndex = 0;
    private float backgroundLength;
    private float cameraPositionX;
    private void Start()
    {
        RestartSubscription = EventBus.Subscribe<RestartEvent>(_OnRestart);
        // Get the Renderer component of the GameObject
        Renderer renderer = backgroundObjects[0].transform.GetComponent<Renderer>();

        // Check if the Renderer component exists
        if (renderer != null)
        {
            Bounds bounds = renderer.bounds;
            backgroundLength = bounds.size.x;
        }
        cameraPositionX = Camera.main.transform.position.x;
    }

    void Update()
    {
        // Get the camera's x position
        cameraPositionX = Camera.main.transform.position.x;

        // Get the x position of the current background object
        float objectPositionX = backgroundObjects[currentIndex].position.x;

        // Check if the camera has passed the current background
        if (cameraPositionX > objectPositionX + backgroundLength)
        {
            // Calculate the new position for the current object
            Vector3 newPosition = backgroundObjects[currentIndex].position + Vector3.right * ((2 * backgroundLength)-0.05f);

            // Reposition the current object at the end
            backgroundObjects[currentIndex].position = newPosition;

            // Cycle to the next background object
            currentIndex = (currentIndex + 1) % backgroundObjects.Length;
        }
    }

    void _OnRestart(RestartEvent e)
    {
        // Get the difference between the current background and the camera
        float difference = backgroundObjects[currentIndex].position.x - player.position.x;
        Debug.Log("Difference: " + difference);
        // Update the positions of all background objects to match the player's new position
        foreach (Transform backgroundObject in backgroundObjects)
        {
            Vector3 updatedPosition = backgroundObject.position;
            updatedPosition.x -= difference;
            GameObject duplicate = Instantiate(backgroundObject.gameObject, updatedPosition, backgroundObject.rotation, backgroundObject.parent);
        }

    }
}