using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float oscillationSpeed;
    public float oscillationDistance;
    private float direction;

    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        oscillationSpeed = 1f;
        oscillationDistance = 90f;
        direction = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.rotation = Quaternion.identity;  // Makes the platform avoid the rotation of the axis

        float angle = Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance;
        transform.rotation = Quaternion.Euler(0, 0, angle * direction);     // Rotates the axis

        // Changes the direction when the oscillation has finished
        if (Mathf.Abs(angle) >= oscillationDistance)
        {
            direction *= -1;
        }
    }
}
