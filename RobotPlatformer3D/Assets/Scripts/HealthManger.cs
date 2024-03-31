using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int maxNumHearts;

    public Image[] hearts;
    public Sprite heartSprite;

    void Start()
    {
        health = 3;
        health = maxNumHearts; // Iniciar con la salud máxima
        UpdateHeartsUI();
    }

    void Update()
    {
        // No necesitas verificar si health > maxNumHearts aquí, ya que health nunca debería ser mayor que maxNumHearts
        // Este chequeo ya está cubierto en OnCollisionEnter

        // Aquí no necesitas actualizar la UI cada frame, solo necesitas actualizarla cuando la salud cambie
        // La actualización de la UI se realiza en OnCollisionEnter
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health > 0)
            {
                health--; // Reducir la salud si aún hay corazones restantes
                UpdateHeartsUI();
                print("Te quedan " + health + " corazones.");
            }
            else
            {
                print("¡El jugador ha perdido toda la salud!");
                // Aquí puedes manejar la lógica de juego adicional cuando el jugador pierde toda su salud
            }
        }
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < maxNumHearts; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = heartSprite; // Mostrar el sprite del corazón si el índice es menor que la salud actual
            }
            else
            {
                hearts[i].sprite = null; // De lo contrario, desactivar el sprite
            }
        }
    }
}
