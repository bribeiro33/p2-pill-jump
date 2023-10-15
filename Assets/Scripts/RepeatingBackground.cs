using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public Transform[] backgroundObjects;

    private int currentIndex = 0;
    private float backgroundLength;
    private void Start()
    {
        // Get the Renderer component of the GameObject
        Renderer renderer = backgroundObjects[0].transform.GetComponent<Renderer>();

        // Check if the Renderer component exists
        if (renderer != null)
        {
            Bounds bounds = renderer.bounds;
            backgroundLength = bounds.size.x;
        }
    }

    void Update()
    {
        // Get the camera's x position
        float cameraPositionX = Camera.main.transform.position.x;

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
}