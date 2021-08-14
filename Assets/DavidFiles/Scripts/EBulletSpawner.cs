using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float shotCooldown = 1f;
    public bool isAttacking = false;

    float currentTime;
    float nextShotTime;

    void Start()
    {

    }

    void Update()
    {
        //isAttacking = get shooting bool from Henry's minion enemy AI script
        if (Time.time > nextShotTime && isAttacking == true)
        {
            nextShotTime = Time.time + shotCooldown;
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }

    }
}
