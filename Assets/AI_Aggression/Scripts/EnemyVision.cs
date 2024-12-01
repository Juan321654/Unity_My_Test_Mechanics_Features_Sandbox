using AI.Aggression;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public Transform target;
    public LayerMask obstacleMask;
    public float detectionRadius = 5f;
    public float fieldOfView = 90f;
    public float moveSpeed = 2f;

    private bool isTargetInSight = false;
    private float detectionInterval = 0.2f;

    void Start()
    {
        InvokeRepeating(nameof(DetectPlayer), 0, detectionInterval);
    }

    void Update()
    {
        if (isTargetInSight)
        {
            Debug.Log("Player detected! Enemy is attacking or following.");
            EnemyUtilities.FollowPlayer(transform, target, moveSpeed);
        }
    }

    void DetectPlayer()
    {
        if (!target) return;

        Vector3 directionToPlayer = (target.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= detectionRadius)
        {
            float dotProduct = Vector3.Dot(transform.forward, directionToPlayer);
            float threshold = Mathf.Cos(fieldOfView * 0.5f * Mathf.Deg2Rad);

            if (dotProduct >= threshold)
            {
                if (!Physics.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                {
                    isTargetInSight = true;
                    return;
                }
            }
        }

        isTargetInSight = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Vector3 leftBoundary = Quaternion.Euler(0, -fieldOfView / 2, 0) * transform.forward * detectionRadius;
        Vector3 rightBoundary = Quaternion.Euler(0, fieldOfView / 2, 0) * transform.forward * detectionRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, leftBoundary);
        Gizmos.DrawRay(transform.position, rightBoundary);
    }
}
