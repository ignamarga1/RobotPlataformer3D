using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    public float maxDistanceY;    
    public float speed;          

    private Vector3 posicionInicial; 

    // Start is called before the first frame update
    void Start()
    {
        maxDistanceY = 1f;
        speed = 3f;
        posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceY = Mathf.Sin(Time.time * speed) * maxDistanceY;
        Vector3 newPosition = posicionInicial + Vector3.up * distanceY;

        // Updates the gameObject position
        transform.position = newPosition;
    }
}
