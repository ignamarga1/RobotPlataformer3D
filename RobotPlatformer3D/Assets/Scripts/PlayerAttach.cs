using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    public GameObject player;
    private bool isPlayerOnPlatform = false;
    private Vector3 lastPlatformPosition;

    void Update()
    {
        if (isPlayerOnPlatform)
        {
            Vector3 platformMovement = transform.position - lastPlatformPosition;
            player.transform.position += platformMovement;
            lastPlatformPosition = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            lastPlatformPosition = transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }


}
