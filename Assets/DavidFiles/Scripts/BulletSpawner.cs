using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject muzzleToLock;
    public GameObject bullet;
    public float shotCooldown = 1f;
    private float fireStart = 0;
    Quaternion direction;
    RaycastHit target;
    float currentTime;
    float nextShotTime;
    int mask;
    public bool isFiring = false;

    void Start()
    {
        mask = LayerMask.GetMask("Default","Terrain");
    }

    void Update()
    {
        this.transform.position = new Vector3(muzzleToLock.transform.position.x, muzzleToLock.transform.position.y, muzzleToLock.transform.position.z);

        if (Input.GetButtonDown("Fire1") && (Time.time > fireStart + shotCooldown))// && canAnimate)
        {
            isFiring = true;
            Physics.Raycast(transform.parent.position,transform.parent.forward,out target,100,mask);
            direction = Quaternion.LookRotation((target.point-transform.position),Vector3.up);
            fireStart = Time.time;
            Instantiate(bullet, transform.position, transform.rotation);//direction);
        }

        if(Time.time < fireStart + shotCooldown)
        {
            isFiring = false;
        }
    }
}
