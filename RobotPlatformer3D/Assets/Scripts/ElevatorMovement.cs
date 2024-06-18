using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private float oscillationSpeed;
    private float oscillationDistance;
    private float direction;
    private float initialAngle;
    private float currentAngle;
    private float velocity = 0.0f; // Smoothing speed

    public GameObject platform;

    void Start()
    {
        oscillationSpeed = 1f;
        oscillationDistance = 100f;
        direction = 1.0f;
        initialAngle = transform.rotation.eulerAngles.y;
    }

    void Update()
    {
        platform.transform.rotation = Quaternion.identity;  // Avoids rotation problems
        float targetAngle = Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance * direction;

        // Smooths the targetAngle using SmoothDampAngle
        currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref velocity, 0.3f);  
        transform.rotation = Quaternion.Euler(0, initialAngle, currentAngle);
    }
}
