using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    public GameObject cannonball;

    float lastShotTime = 0;
    float shotInterval = 3f;

    private void FixedUpdate()
    {
        if(Time.time > (lastShotTime + shotInterval))
        {
            GameObject x = Instantiate(cannonball, transform.position, transform.rotation);
            Destroy(x, 0.75f);
            lastShotTime = Time.time;
        } 
    }
}
