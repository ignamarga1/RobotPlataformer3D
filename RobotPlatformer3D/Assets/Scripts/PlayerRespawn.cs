using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    //private Vector3 spawnPoint = new Vector3(0, 0, -110); // Level 1
    private Vector3 spawnPoint = new Vector3(100, 2, 12);   // Level 2

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y < -20f)
        {
            transform.position = spawnPoint;
        }
    }
}
