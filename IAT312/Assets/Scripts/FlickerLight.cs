using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light targetLight;  // Drag your Light component here
    public float minOnTime = 5.0f;  // Minimum time light stays on
    public float maxOnTime = 10.0f;  // Maximum time light stays on
    public float minOffTime = 0.1f;  // Minimum time light stays off
    public float maxOffTime = 0.5f;  // Maximum time light stays off

    private float nextActionTime;
    private bool isLightOn = true;

    void Start()
    {
        // Set the initial time based on whether the light is initially on or off
        nextActionTime = Time.time + (isLightOn ? Random.Range(minOnTime, maxOnTime) : Random.Range(minOffTime, maxOffTime));
    }

    void Update()
    {
        // Check if it's time for the next action (either turn the light on or off)
        if (Time.time >= nextActionTime)
        {
            // Toggle the light status
            isLightOn = !isLightOn;
            targetLight.enabled = isLightOn;

            // Set the time for the next action based on the new light status
            nextActionTime = Time.time + (isLightOn ? Random.Range(minOnTime, maxOnTime) : Random.Range(minOffTime, maxOffTime));
        }
    }
}
