using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float velZ = 8;
    float velRot = 130;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up * h * velRot * Time.deltaTime);
        transform.Translate(Vector3.forward * v * velZ * Time.deltaTime);
    }
}
