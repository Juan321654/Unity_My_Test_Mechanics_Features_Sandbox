using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;

    private bool isPlayerInRange = false;

    private void Awake() {
        if (target == null) {
            Debug.LogError("Target is not set, please set the target");
            enabled = false; // stops the script from running
        }
    }

    void Update()
    {
        if (isPlayerInRange) FollowPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Something Entered: {other.tag}, {other.name}");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void FollowPlayer()
    {
        Debug.Log("Following Player");
        transform.LookAt(target);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
