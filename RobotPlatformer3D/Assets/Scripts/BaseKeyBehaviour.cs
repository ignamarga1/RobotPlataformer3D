using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseKeyBehaviour : MonoBehaviour
{
    public GameObject chest;
    private Animator animator;

    private void Start()
    {
        animator = chest.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);  // Destroys the key when collides with the base
            animator.SetBool("isKeyInBase", true);  // Makes the chest play the open animation
        }
    }
}
