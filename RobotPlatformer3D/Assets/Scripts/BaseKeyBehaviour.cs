using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseKeyBehaviour : MonoBehaviour
{
    public GameObject chest;
    private Animator animator;
    private float finishTime;

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
            finishTime = Time.time;

            Invoke("LoadVictoryScene", 5f);
        }
    }

    private void LoadVictoryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
