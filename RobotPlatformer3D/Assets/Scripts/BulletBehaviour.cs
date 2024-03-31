using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float impactForce;

    // Update is called once per frame
    void Update()
    {
        impactForce = 1000f;
        transform.Translate(Vector3.forward * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.gameObject;
        CharacterController jugadorController = player.GetComponent<CharacterController>();
        if (player.gameObject.CompareTag("Player"))
        {
            print(gameObject.name + "ha impactado en el jugador");

            // Verifica si el objeto impactado tiene un CharacterController
            if (jugadorController != null)
            {
                // Calcula la dirección del impacto
                Vector3 direccionImpacto = (player.transform.position - transform.position).normalized;
                // Aplica movimiento al CharacterController del jugador en la dirección opuesta al impacto
                jugadorController.Move(direccionImpacto * impactForce * Time.deltaTime);
            }

            //Código sobre efectos. Ej. activar animación de jugadorImpactado cayendo … y quitarle algo de Salud
            print("Impacto con " + player.name);

            // Destruye la bala después de impactar
            Destroy(gameObject);
        }
    }
}
