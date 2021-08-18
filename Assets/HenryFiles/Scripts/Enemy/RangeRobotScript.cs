using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRobotScript : MonoBehaviour
{

    //public GameObject bullet;
    public float fireRate = 4;
    public float nextFire;
    public float relockRate = 7;
    public float nextLock;
    public Transform Player;
    public Transform rightGun;
    public Transform leftGun;
    public bool isRangedEnemy = true;
    public bool canShootE_1 = true;
    public bool isShooting;
    public float enemyWeaponRange = 15.0f;
    public float BulletForwardForce = 5;
    public float speed = 4f;
    public float minDist = 1f;
    public Transform target;
    public float enemyRange = 40;
    public bool isTargetingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        nextLock = 0f;
        nextFire = 0;
        canShootE_1 = true;
        // if no target specified, assume the player
        if (Player == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (GameObject.FindWithTag("Player") == null)
            {
                Object.Destroy(gameObject);
            }
        }

        if (Player != null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (GameObject.FindWithTag("Player") == null)
            {
                Object.Destroy(gameObject);
            }
        }

        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;

        if ((Vector3.Distance(Player.position, this.transform.position) < 15.0f))// && (Vector3.Distance(Player.position, this.transform.position) > 200.0f))
        {
            speed = 7f;
            transform.position -= transform.forward * speed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            //transform.LookAt(Vector3(otherObject.position.x, transform.position.y, otherObject.position.z));
        }
        else if ((Vector3.Distance(Player.position, this.transform.position) < 100.0f) && (Vector3.Distance(Player.position, this.transform.position) > 35.0f))
        {
            speed = 4f;
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.LookAt(Player.position);

        }
        else
        {
            speed = 0f;
        }

        CheckIfTimeToFire();
        //Movement

        if (target == null)
            return;

        //float distance = Vector3.Distance(transform.position, target.position);

    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire && canShootE_1 == true && (Vector3.Distance(Player.position, transform.position) < enemyWeaponRange))
        {

            if (isRangedEnemy)
            {
                isShooting = true;
                nextFire = Time.time + fireRate;
                canShootE_1 = false;
                loadEnemyWeapon();
            }
        }
    }

    void loadEnemyWeapon()
    {
        if (Time.time > nextFire)
        {
               canShootE_1 = true;
        }
        else
        {
            isShooting = false;
        }
    }
}