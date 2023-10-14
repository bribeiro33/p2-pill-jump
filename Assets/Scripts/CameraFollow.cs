using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Assign the player's transform in the inspector
    public float cameraOffset = 2.0f;

    void Update()
    {
        float camXPos = target.position.x + cameraOffset;
        transform.position = new Vector3(camXPos, transform.position.y, transform.position.z);
    }
}
