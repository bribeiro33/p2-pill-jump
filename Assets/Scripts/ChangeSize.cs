using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float scaleFactor = 0.1f;  // How much to scale per key press
    public float maxLength = 3.0f;    // Max length for the capsule
    public float minLength = 0.5f;    // Minimum length for the capsule

    private float currentHeight = 1.0f;
    private bool isGrowing = false;
    private bool isShrinking = false;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            isGrowing = true;
            isShrinking = false;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            isShrinking = true;
            isGrowing = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            isGrowing = false;
            isShrinking = false;
        }

        if (isGrowing)
        {
            Grow();
        }
        else if (isShrinking)
        {
            Shrink();
        }
    }

    void Grow()
    {
        currentHeight += scaleFactor * Time.deltaTime;

        // Clamp the target scale to min and max values
        currentHeight = Mathf.Clamp(currentHeight, minLength, maxLength);

        // Calculate the target scale with the new Y-axis height
        Vector3 targetScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z);

        // Use Mathf.Lerp to smoothly interpolate the Y-axis scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.1f);
    }

    void Shrink()
    {
        currentHeight -= scaleFactor * Time.deltaTime;

        // Clamp the target scale to min and max values
        currentHeight = Mathf.Clamp(currentHeight, minLength, maxLength);

        // Calculate the target scale with the new Y-axis height
        Vector3 targetScale = new Vector3(transform.localScale.x, currentHeight, transform.localScale.z);

        // Use Mathf.Lerp to smoothly interpolate the Y-axis scale
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.1f);
    }
}
