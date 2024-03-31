using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float impactForce = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        if(player.gameObject.CompareTag("Player"))
        {
            print(gameObject.name + "ha impactado en el jugador");
        }
    }
}
