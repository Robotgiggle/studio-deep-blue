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
        if(GetComponentInParent<RangeRobotScript>().whatIsTarget != null)
        {
            transform.LookAt(new Vector3(GetComponentInParent<RangeRobotScript>().whatIsTarget.position.x, GetComponentInParent<RangeRobotScript>().whatIsTarget.transform.position.y, GetComponentInParent<RangeRobotScript>().whatIsTarget.transform.position.z));
        }
        //isAttacking = get shooting bool from Henry's minion enemy AI script
        isAttacking = GetComponentInParent<RangeRobotScript>().isShooting;
        if (Time.time > nextShotTime && isAttacking == true && GetComponentInParent<Enemy_1_Health>().isDead != true)
        {
            nextShotTime = Time.time + shotCooldown;
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }

    }
}
