using System.Collections;
using UnityEngine;
public class SteeringWheelRotation : MonoBehaviour
{
    [Range(-45f, 45f)]
    public float steeringWheelRotationAmount = 0f;
    public float wheelRotationDampening = 0.5f;
    public Transform frontLeftWheel, frontRightWheel;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -steeringWheelRotationAmount);
    }
}