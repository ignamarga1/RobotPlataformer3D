using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    public float rotationAngleZ;
    public GameObject platform;

    public float oscillationSpeed;   // Velocidad de oscilación
    public float oscillationDistance; // Distancia de oscilación en grados

    private float direction;


    // Start is called before the first frame update
    void Start()
    {
        rotationAngleZ = 90;
        oscillationSpeed = 1f;
        oscillationDistance = 90f;
        direction = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        platform.transform.rotation = Quaternion.identity;

        float angle = Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance;
        transform.rotation = Quaternion.Euler(0, 0, angle * direction);

        // Cambiar la dirección si llegamos al extremo
        if (Mathf.Abs(angle) >= oscillationDistance)
        {
            direction *= -1;
        }
    }
}
