using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float shotCooldown = 1f;

    float currentTime;
    float nextShotTime;

    void Start()
    {

    }

    void Update()
    {
        if ((Time.time > nextShotTime) && Input.GetButtonDown("Fire1"))
        {
            nextShotTime = Time.time + shotCooldown;
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }

    }
}
