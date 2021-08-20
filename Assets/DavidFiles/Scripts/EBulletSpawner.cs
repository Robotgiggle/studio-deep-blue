using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBulletSpawner : MonoBehaviour
{
    public GameObject bullet;
    public float shotCooldown = 1f;
    public float inaccuracy;
    public bool isAttacking = false;
    Vector3 direction;
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
        if (Time.time > nextShotTime && GetComponentInParent<Enemy_1_Health>().isDead != true && GetComponentInParent<RangeRobotScript>().enemyIsInRange)
        {
            direction = transform.rotation.eulerAngles;
            direction.x += Random.Range(-inaccuracy,inaccuracy);
            direction.y += Random.Range(-inaccuracy,inaccuracy);
            direction.z += Random.Range(-inaccuracy,inaccuracy);
            Instantiate(bullet, this.transform.position, Quaternion.Euler(direction));
            nextShotTime = Time.time + shotCooldown;
        }

    }
}
