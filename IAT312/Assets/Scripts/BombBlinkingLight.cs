using UnityEngine;

public class BombBlinkingLight : MonoBehaviour
{
    public Light bombLight;  // Reference to the Light component
    public float blinkInterval = 0.5f;  // Interval between blinks in seconds
    public bool isBlinkingEnabled = true;  // Control if the light should blink

    private float nextBlinkTime;

    void Start()
    {
        // Initialize the next blink time
        nextBlinkTime = Time.time + blinkInterval;
    }

    void Update()
    {
        // Only blink if isBlinkingEnabled is true
        if (isBlinkingEnabled)
        {
            // Check if it's time to blink
            if (Time.time >= nextBlinkTime)
            {
                // Toggle the light
                bombLight.enabled = !bombLight.enabled;

                // Update the next blink time
                nextBlinkTime = Time.time + blinkInterval;
            }
        }
        else
        {
            // Turn off the light if blinking is disabled
            bombLight.enabled = false;
        }
    }

    // Function to enable blinking
    public void EnableBlinking()
    {
        isBlinkingEnabled = true;
    }

    // Function to disable blinking and turn off the light
    public void DisableBlinking()
    {
        isBlinkingEnabled = false;
        bombLight.enabled = false;
    }
}
