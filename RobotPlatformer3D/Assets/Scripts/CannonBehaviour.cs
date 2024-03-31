using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    public GameObject bullet;

    float lastShotTime = 0;
    float shotInterval = 3f;

    private void FixedUpdate()
    {
        if(Time.time - lastShotTime > shotInterval)
        {
            GameObject x = Instantiate(bullet, transform.position, transform.rotation);
            Destroy(x, 10f);
            lastShotTime = Time.time;
        } 
    }
}
