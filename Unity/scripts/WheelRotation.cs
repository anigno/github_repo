using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    private float WheelSpeed = 0f;
    private Vector3 prev_position = Vector3.zero;
    private float MAX_SPEED = 9999f;
    public static float Direction = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WheelSpeed = (transform.position - prev_position).magnitude * MAX_SPEED;
        transform.Rotate(Vector3.up * -WheelSpeed * Direction * Time.deltaTime);
        prev_position = transform.position;
    }
}
