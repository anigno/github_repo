using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ControllerTankSimple : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 30f;
    public Transform Transform;

    void Start()
    {
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        Transform.Translate(0, 0, translation);
        Transform.Rotate(0, rotation, 0);
        if (translation > 0) WheelRotation.Direction = 1; else WheelRotation.Direction = -1;
    }
}
