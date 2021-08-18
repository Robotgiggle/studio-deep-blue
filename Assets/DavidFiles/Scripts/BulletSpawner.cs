using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawnPoint;
    public float shotCooldown = 1f;
    //public GameObject animationCoordinator;
    //public bool canAnimate = false;

    private float fireCooldown = 2f;
    private float fireStart = 0;
    float currentTime;
    float nextShotTime;

    void Start()
    {

    }

    void Update()
    {
        //canAnimate = animationCoordinator.GetComponent<WeaponSound>().canAnimate;
        if (Input.GetButtonDown("Fire1") && (Time.time > fireStart + fireCooldown))// && canAnimate)
        {
            fireStart = Time.time;
             //nextShotTime = Time.time + shotCooldown;
            Instantiate(bullet, bulletSpawnPoint.transform.position, this.transform.rotation);
        }
    }
}
