using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speedZ = 20;
    float rotationSpeed = 720;
    float jumpForce = 10;
    //float gravity = -9.81f;
    //float jumpHeight = 3;
    //Vector3 velocity;

    private Animator animator;
    private Rigidbody rb;
    public Transform transformCamera; 

    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento vertical y horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * verticalInput * velZ * Time.deltaTime);
        //transform.Rotate(Vector3.up * horizontalInput * velRot * Time.deltaTime);

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection = Quaternion.AngleAxis(transformCamera.rotation.eulerAngles.y, Vector3.up) * movementDirection;   // Ajuste cámara
        movementDirection.Normalize();
        transform.Translate(movementDirection * speedZ * Time.deltaTime, Space.World);

        // Salto del personaje
        if(isOnGround && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            animator.SetBool("isJumping", true);
        }
        
        // Si el personaje se esté moviendo
        if (movementDirection != Vector3.zero)
        {
            //transform.forward = movementDirection;  // Para que el personaje se gire
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed*Time.deltaTime);    // Personaje giro mejorado
            
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Suelo"))
        {
            isOnGround = true;
            animator.SetBool("isJumping", false);
        }
    }
}
