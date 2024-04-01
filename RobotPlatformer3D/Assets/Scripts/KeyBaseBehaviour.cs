using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBaseBehaviour : MonoBehaviour
{
    public GameObject chest;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = chest.GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            print(other.gameObject.name + "He colisionado");
            Destroy(other.gameObject);
            animator.SetBool("isKeyInBase", true);
        }
    }
}
