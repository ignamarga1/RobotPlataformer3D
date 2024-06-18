using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    public GameObject cannonball;

    float lastShotTime = 0;
    float shotInterval = 1.25f;

    private void FixedUpdate()
    {
        if(Time.time > (lastShotTime + shotInterval))
        {
            GameObject x = Instantiate(cannonball, transform.position, transform.rotation);
            Destroy(x, 1f);
            lastShotTime = Time.time;
        } 
    }
}
