using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject target;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError($"Rigidbody not found in {gameObject.name}. Disabling script.");
            enabled = false; // Disable this script to avoid further errors
        }

        if (target == null)
        {
            Debug.LogError($"Target not assigned in {gameObject.name}. Disabling script... drop a GameObject in the Target field.");
            enabled = false; // Disable this script to avoid further errors
        }
    }

    void Update()
    {
        FollowTargetNormalized();
    }

    void FollowTargetNormalized()
    {
        // Debug.Log("Following target");
        Vector3 direction = (target.transform.position - transform.position).normalized;
        rb.AddForce(direction * speed);
    }
}
