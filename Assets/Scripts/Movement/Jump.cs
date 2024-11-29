using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError($"Rigidbody not found in {gameObject.name}. Disabling script.");
            enabled = false; // Disable this script to avoid further errors
        }
    }

    // Update is called once per frame
    void Update()
    {
        JumpAction();
    }

    void JumpAction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
