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
    private float velocity = 0.0f; // Velocidad actual del suavizado

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
        platform.transform.rotation = Quaternion.identity;  // Hace que la plataforma evite la rotación del eje

        // Calcula el ángulo objetivo usando Mathf.Sin
        float targetAngle = Mathf.Sin(Time.time * oscillationSpeed) * oscillationDistance * direction;

        // Suaviza la transición al ángulo objetivo usando Mathf.SmoothDampAngle
        currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref velocity, 0.3f);  // 0.3f es el tiempo de suavizado, puedes ajustarlo

        // Aplica la rotación suavizada empezando desde el ángulo inicial
        transform.rotation = Quaternion.Euler(0, initialAngle, currentAngle);
    }
}
