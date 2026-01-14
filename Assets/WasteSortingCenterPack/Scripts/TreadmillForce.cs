using UnityEngine;

public class TreadmillForce : MonoBehaviour
{
    public float currentSpeed { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody body = other.attachedRigidbody;
        if (body != null)
        {
            Vector3 velocity = body.velocity;
            velocity = transform.InverseTransformVector(velocity);
            velocity.z = currentSpeed;
            velocity = transform.TransformVector(velocity);
            body.velocity = velocity;
        }
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }
}
