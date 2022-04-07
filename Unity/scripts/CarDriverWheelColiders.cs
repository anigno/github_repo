using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class CarDriverWheelColiders : MonoBehaviour
{
    public float MotorForce, SteerForce, BrakeForce;
    public WheelCollider FR, FL, RR, RL;
    public float RPM;
    public float SpeedKph;
    public Transform WheelR;
    public Transform WheelL;


    void Start()
    {

    }

    void Update()
    {
        float v = Input.GetAxis("Vertical") * MotorForce;
        float h = Input.GetAxis("Horizontal") * SteerForce;
        RR.motorTorque = v;
        RL.motorTorque = v;
        FR.steerAngle = h;
        FL.steerAngle = h;
        if (Math.Abs(v) < 0.1) RR.motorTorque = RL.motorTorque = RR.brakeTorque = RL.brakeTorque = 0f;
        if (Math.Abs(h) < 0.1) FR.steerAngle = FL.steerAngle = 0f;

        if (v < 0) RR.brakeTorque = RL.brakeTorque = BrakeForce;
        RPM = RR.rpm;

        Quaternion quat;
        Vector3 pos;
        FR.GetWorldPose(out pos, out quat);
        //WheelR.position = pos;
        WheelR.rotation = quat;
        //WheelL.position = pos;
        WheelL.rotation = quat;
        SpeedKph = RR.attachedRigidbody.velocity.magnitude * 3.6f;


    }
}
