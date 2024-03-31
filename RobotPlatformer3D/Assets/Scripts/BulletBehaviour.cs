using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 50f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        GameObject jugadorImpactado = collider.gameObject;
        //Código sobre efectos. Ej. activar animación de jugadorImpactado cayendo … y quitarle algo de Salud
    }
}
