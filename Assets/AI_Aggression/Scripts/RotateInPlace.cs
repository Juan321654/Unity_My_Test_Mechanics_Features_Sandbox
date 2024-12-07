using UnityEngine;

public class RotateInPlace : MonoBehaviour
{
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.down, 90f * Time.deltaTime);
    }
}
