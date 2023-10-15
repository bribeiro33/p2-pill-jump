using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float scaleFactor = 0.1f;  // How much to scale per key press
    public float maxLength = 3.0f;    // Max length for the capsule
    public float minLength = 0.5f;    // Minimum length for the capsule
    public float currentHeight = 1.0f;

    private Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Grow();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Shrink();
        }*/
        float scaleChange = Input.GetAxis("Vertical") * scaleFactor * Time.deltaTime;
        currentHeight += scaleChange;

        // Clamp the target scale to min and max values
        currentHeight = Mathf.Clamp(currentHeight, minLength, maxLength);

        // Calculate the target scale with the new Y-axis height
        Vector3 targetScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z);

        // Use Mathf.Lerp to smoothly interpolate the Y-axis scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.1f);
    }

    // Increases object's size
    void Grow() //// Should this be in fixed update?
    {
        Vector3 newScale = transform.localScale;  // Get current scale
        newScale.y += scaleFactor;  // Increase the Y scale

        // Clamp the Y scale to make sure it doesn't exceed maxLength
        newScale.y = Mathf.Min(newScale.y, maxLength);

        transform.localScale = newScale;  // Set the new scale
    }

    // Decreases object's size
    void Shrink()
    {
        Vector3 newScale = transform.localScale;  // Get current scale
        newScale.y -= scaleFactor;  // Decrease the Y scale

        // Clamp the Y scale to make sure it doesn't go below minLength
        newScale.y = Mathf.Max(newScale.y, minLength);

        transform.localScale = newScale;  // Set the new scale
    }

}
