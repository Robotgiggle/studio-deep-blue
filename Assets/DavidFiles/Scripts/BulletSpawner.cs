using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float shotCooldown = 1f;
    private float fireStart = 0;
    Quaternion direction;
    RaycastHit target;
    float currentTime;
    float nextShotTime;
    int mask = 9;
    public bool animate = false;
    public bool isFiring = false;

    void Start()
    {

    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && (Time.time > fireStart + shotCooldown) && Time.timeScale != 0)
        {
            Physics.Raycast(transform.parent.position,transform.parent.forward,out target,100,mask);
            direction = Quaternion.LookRotation((target.point-transform.position),Vector3.up);
            fireStart = Time.time;
            Instantiate(bullet, transform.position, direction);
            if(animate){isFiring = true;}
        }

        if(Time.time > fireStart + shotCooldown)
        {
            isFiring = false;
        }
    }
}
