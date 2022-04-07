using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGamePad : MonoBehaviour
{
    public Transform MovingBody;
    public float MoveScale = 10f;
    public float RotateScale = 90f;

    void Start()
    {
    }

    void Update()
    {
        float axes_1_x = Input.GetAxis("Horizontal");
        float axes_1_y = Input.GetAxis("Vertical");
        float axes_2_x = Input.GetAxis("RightStickHorizontal");
        float axes_2_y = Input.GetAxis("RightStickVertical");

        MovingBody.transform.position = Vector3.up * axes_1_y * MoveScale + Vector3.right * axes_1_x * MoveScale;
        MovingBody.transform.rotation = Quaternion.Euler(axes_2_y * RotateScale, axes_2_x * RotateScale, 0);

    }
}
