using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformMovement : MonoBehaviour
{
    public float speed;           // Velocidad de movimiento
    public Vector3 startPosition;        // Posición inicial
    public Vector3 endPosition;          // Posición final
    private bool movingUp = true;        // Indica si se está moviendo hacia arriba

    // Start is called before the first frame update
    void Start()
    {
        speed = 6.0f;

        // Si no se han asignado posiciones, se establecen las posiciones iniciales por defecto
        if (startPosition == Vector3.zero)
        {
            startPosition = transform.position;
        }

        if (endPosition == Vector3.zero)
        {
            endPosition = startPosition + new Vector3(0, 10.0f, 0);  // Mueve 10 unidades hacia arriba como valor por defecto
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve la plataforma hacia la posición objetivo
        if (movingUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
            if (transform.position == endPosition)
            {
                movingUp = false;  // Cambia de dirección cuando llega al final
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
            if (transform.position == startPosition)
            {
                movingUp = true;  // Cambia de dirección cuando llega al inicio
            }
        }
    }
}
