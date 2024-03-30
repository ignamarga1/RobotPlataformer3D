using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedZ;
    public float rotationSpeed;
    public float jumpSpeed;
    public float speedY;

    private Animator animator;
    public Transform transformCamera;
    public CharacterController characterController;

    private bool isOnGround;

    // Start is called before the first frame update
    void Start()
    {
        speedZ = 20;
        rotationSpeed = 720;
        jumpSpeed = 10;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();  
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento vertical y horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Sqrt(movementDirection.magnitude) * speedZ;
        movementDirection = Quaternion.AngleAxis(transformCamera.rotation.eulerAngles.y, Vector3.up) * movementDirection;   // Ajuste cámara
        movementDirection.Normalize();

        speedY += Physics.gravity.y * Time.deltaTime;   // Decreases the Y speed in 9.81 every second

        //transform.Translate(movementDirection * speedZ * Time.deltaTime, Space.World);

        // Salto del personaje
        if(characterController.isGrounded)
        {
            isOnGround = true;
            animator.SetBool("isJumping", false);
            speedY = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isOnGround = false;
                speedY = jumpSpeed;
                animator.SetBool("isJumping", true);
            }
        }
            
        

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = speedY;
        characterController.Move(velocity * Time.deltaTime);

        // Si el personaje se esté moviendo
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);    // Personaje giro mejorado

            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}