using UnityEngine;

public class Scaling : MonoBehaviour
{
    public float scaleSpeed = 2.0f;   // Speed of scaling
    public float maxScale = 2.0f;     // Maximum scale
    public float scaleDuration = 2.0f; // Time it takes to scale

    private Vector3 originalScale;
    private bool isScalingXUp = true;
    private bool isScalingYUp = false; // Initialize Y scaling direction as opposite of X
    private float scaleXStartTime;
    private float scaleYStartTime;

    void Start()
    {
        originalScale = transform.localScale;
        scaleXStartTime = Time.time;
        scaleYStartTime = Time.time;
    }

    void Update()
    {
        // Calculate the progress for X and Y scaling separately
        float progressX = (Time.time - scaleXStartTime) / scaleDuration;
        float progressY = (Time.time - scaleYStartTime) / scaleDuration;

        // Determine the target scale based on the current scaling direction
        Vector3 targetScale = new Vector3(
            isScalingXUp ? originalScale.x * maxScale : originalScale.x,
            isScalingYUp ? originalScale.y * maxScale : originalScale.y,
            transform.localScale.z
        );

        // Use Lerp to smoothly interpolate the scale for X and Y separately
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);

        // Check if we've reached the target scale for X
        if (progressX >= 1.0f)
        {
            // Toggle the scaling direction for X
            isScalingXUp = !isScalingXUp;

            // Reset the start time for X scaling
            scaleXStartTime = Time.time;
        }

        // Check if we've reached the target scale for Y
        if (progressY >= 1.0f)
        {
            // Toggle the scaling direction for Y
            isScalingYUp = !isScalingYUp;

            // Reset the start time for Y scaling
            scaleYStartTime = Time.time;
        }
    }
}
