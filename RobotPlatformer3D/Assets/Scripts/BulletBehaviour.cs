using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float impactForce;

    // Update is called once per frame
    void Update()
    {
        impactForce = 1000f;    // Force that the bullet will apply when collides with the player
        transform.Translate(Vector3.forward * 50f * Time.deltaTime);    // Moves the bullet forward
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        CharacterController characterController = player.GetComponent<CharacterController>();
        
        if (player.gameObject.CompareTag("Player"))
        {
            // Checks if the collisioned player has a CharacterController
            if (characterController != null)
            {
                Vector3 impactDirection = (player.transform.position - transform.position).normalized;
                characterController.Move(impactDirection * impactForce * Time.deltaTime);   // Moves the player in the impactDirection
            }
            
            Destroy(gameObject);    // Destroys the bullet after colliding with the player
        }
    }
}
