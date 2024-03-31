using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeAndRelease : MonoBehaviour
{
    // Objeto actualmente agarrado por el jugador
    private GameObject ObjetoObjetivo;

    // Variable para rastrear la intención de soltar
    private bool intencionSoltar = false;

    // Variable para rastrear la intención de tomar
    private bool intencionTomar = true; // Al principio, la intención de tomar es verdadera

    // GameObject vacío para posicionar el objeto objetivo
    public GameObject puntoDeAgarre;

    // Distancia desde el jugador para soltar el objeto
    public float distanciaSoltar = 2f;
    public float alturaSoltar = 8f;

    // Referencia al CharacterController
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        alturaSoltar = 8f;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && ObjetoObjetivo != null)
        {
            intencionSoltar = true;
        }

        if (intencionSoltar)
        {
            // intención de soltar el objeto
            SoltaObjeto();
        }
    }

    private void SoltaObjeto()
    {
        // Suelta el objeto
        ObjetoObjetivo.transform.SetParent(null); // el objeto deja de tener padre

        if (ObjetoObjetivo.GetComponent<Rigidbody>() != null)
            ObjetoObjetivo.GetComponent<Rigidbody>().isKinematic = false; // si tiene rigidbody, se vuelve físico

        ObjetoObjetivo.GetComponent<KeyMovement>().enabled = false; // Desactiva el script KeyRotation

        // Calcula la posición frente al jugador para soltar el objeto
        Vector3 posicionSoltar = transform.position + transform.forward * distanciaSoltar;

        // Ajusta la posición de soltar para que esté más alto
        posicionSoltar += Vector3.up * alturaSoltar;

        ObjetoObjetivo.transform.position = posicionSoltar; // Establece la posición del objeto para soltarlo

        ObjetoObjetivo = null; // restablecer el objeto objetivo

        intencionTomar = true; // Cambiar la intención de tomar de vuelta a true
        intencionSoltar = false; // Cambiar la intención de soltar a false
    }




    private void OnTriggerEnter(Collider other)
    {
        // Un Collider con Trigger toca un objeto
        if (intencionTomar && (ObjetoObjetivo == null) && (other.gameObject.tag == "Key"))
        {
            // El objeto pasa a ser hijo del punto de agarre
            other.gameObject.transform.SetParent(puntoDeAgarre.transform);

            // Posicionando el objeto en el punto de agarre
            other.gameObject.transform.localPosition = Vector3.zero;

            if (other.gameObject.GetComponent<Rigidbody>() != null)
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true; // el objeto se vuelve cinemático

            other.gameObject.GetComponent<KeyMovement>().enabled = false; // Desactiva el script KeyRotation

            ObjetoObjetivo = other.gameObject; // establecer el nuevo objeto objetivo

            intencionTomar = false; // Cambiar la intención de tomar a false una vez que se toma el objeto
        }
    }
}
