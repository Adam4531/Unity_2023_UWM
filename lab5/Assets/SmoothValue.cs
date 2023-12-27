using UnityEngine;

public class SmoothValue : MonoBehaviour
{
    // Smooth towards the height of the target

    public Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    void Update()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        // float newPosition = Mathf.Lerp(transform.position.y, target.position.y, smoothTime);
        transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
    }
}