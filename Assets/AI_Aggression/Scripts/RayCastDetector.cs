using System;
using UnityEngine;

public class RaycastDetector : MonoBehaviour
{
    public float rayDistance = 15f;
    public Color rayColor = Color.green;
    public LayerMask detectionLayer = ~0; // Default to 'Everything'
    public string targetTag = "Player"; // Dynamic tag, configurable in the Inspector
    public event Action OnTargetDetected; // Event triggered when the target is detected

    void Update()
    {
        Vector3 rayOrigin = transform.position;
        Vector3 rayDirection = transform.forward;

        // Perform raycast
        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hit, rayDistance, detectionLayer))
        {
            // Debug.Log("Raycast hit: " + hit.collider.name);
            // Check if the hit object has the dynamic tag
            if (!string.IsNullOrEmpty(targetTag) && hit.collider.CompareTag(targetTag))
            {
                // Debug.Log($"{targetTag} detected: " + hit.collider.name);
                Debug.DrawRay(rayOrigin, rayDirection * hit.distance, rayColor);

                // Trigger the detection event
                OnTargetDetected?.Invoke();
            }
        }
        else
        {
            // Visualize the ray when there's no hit
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, rayColor);
        }
    }
}
