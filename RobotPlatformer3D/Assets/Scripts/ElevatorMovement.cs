using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private float oscillationSpeed;
    private float oscillationDistance;
    private float direction;
    private float initialAngle;

    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        oscillationSpeed = 1f;
        oscillationDistance = 100f;
        direction = 1.0f;
        initialAngle = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.rotation = Quaternion.identity;  // Makes the platform avoid the rotation of the axis

        float angle = Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance;
        transform.rotation = Quaternion.Euler(0, initialAngle, angle * direction);  // Rotates the axis starting from the initial angle
    }
}
