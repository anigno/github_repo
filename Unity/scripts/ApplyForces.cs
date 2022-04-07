using UnityEngine;

public class ApplyForces : MonoBehaviour
{
    public Rigidbody rb;
    public float maxMotorTorque=10f;
    public float maxSteeringAngle=10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        rb.AddForce(transform.forward * motor);
        rb.AddTorque(Vector3.up*steering, ForceMode.VelocityChange);
    }
}