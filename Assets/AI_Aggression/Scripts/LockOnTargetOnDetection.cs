using UnityEngine;

public class LockOnTargetOnDetection : MonoBehaviour
{
    public Transform headTransform; // The part of the turret/character to rotate (e.g., the head)
    public RaycastDetector detector; // Reference to the RaycastDetector script
    private Transform detectedTarget; // Store the detected target's transform
    public float rotationSpeed = 5f; // Speed of rotation

    void Start()
    {
        if (detector == null)
        {
            Debug.LogError("RaycastDetector not assigned in " + gameObject.name + ". Disabling script.");
            Debug.LogError("Please assign the RaycastDetector script in the Inspector.");
            enabled = false; // Disable this script to avoid further errors
        }
        else
        {
            detector.OnTargetDetected += LockOnTarget;
        }
    }

    private void LockOnTarget()
    {
        // Get the target detected by the RaycastDetector
        Ray ray = new Ray(detector.transform.position, detector.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, detector.rayDistance, detector.detectionLayer))
        {
            if (hit.collider.CompareTag(detector.targetTag))
            {
                detectedTarget = hit.collider.transform; // Store the target's transform
                Debug.Log($"Locking on target: {detectedTarget.name}");
            }
        }
    }

    void Update()
    {
        if (detectedTarget != null && headTransform != null)
        {
            headTransform.LookAt(detectedTarget);
        }
    }
}
