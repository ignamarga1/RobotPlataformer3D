using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotation : MonoBehaviour
{
    public float distanciaMaxima;    // Distancia máxima a la que se moverá hacia arriba
    public float velocidad;          // Velocidad del movimiento

    private Vector3 posicionInicial; 

    // Start is called before the first frame update
    void Start()
    {
        distanciaMaxima = 1f;
        velocidad = 3f;
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float desplazamiento = Mathf.Sin(Time.time * velocidad) * distanciaMaxima;
        Vector3 nuevaPosicion = posicionInicial + Vector3.up * desplazamiento;

        // Actualizamos la posición del GameObject
        transform.position = nuevaPosicion;
    }
}
