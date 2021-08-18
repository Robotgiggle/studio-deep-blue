using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRobotScript : MonoBehaviour
{

    //public GameObject bullet;
    public float fireRate = 5;
    public float nextFire;
    public Transform whatIsTarget;
    public Transform playerLogTransform;
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
        canShootE_1 = true;
        // if no target specified, assume the player
        if (whatIsTarget == null)
        {
            //"coreTargetTag"
            if (GameObject.FindWithTag("coreTargetTag") != null)
            {
                whatIsTarget = GameObject.FindWithTag("coreTargetTag").GetComponent<Transform>();
            }
            if (GameObject.FindWithTag("Player") != null)
            {
                playerLogTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = whatIsTarget.position - transform.position;
        displacement = displacement.normalized;

        if (whatIsTarget == null)
        {
            if ((GameObject.FindWithTag("coreTargetTag") != null) && ((Vector3.Distance(whatIsTarget.position, this.transform.position) > 25.0f)))
            {
                whatIsTarget = GameObject.FindWithTag("coreTargetTag").GetComponent<Transform>();
            }
            else if ((GameObject.FindWithTag("Player") != null) && ((Vector3.Distance(playerLogTransform.position, this.transform.position) < 25.0f)))
            {
                whatIsTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
            if (GameObject.FindWithTag("coreTargetTag") == null)
            {
                Object.Destroy(gameObject);
            }
            if (GameObject.FindWithTag("Player") != null)
            {
                playerLogTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (GameObject.FindWithTag("Player") == null)
            {
                //Object.Destroy(gameObject);
            }
        }

        if (whatIsTarget != null)
        {
            if ((GameObject.FindWithTag("coreTargetTag") != null) && ((Vector3.Distance(whatIsTarget.position, this.transform.position)) > 30.0f && ((Vector3.Distance(playerLogTransform.position, this.transform.position) > 25.0f))))
            {
                whatIsTarget = GameObject.FindWithTag("coreTargetTag").GetComponent<Transform>();
            }
            else if ((GameObject.FindWithTag("Player") != null) && ((Vector3.Distance(playerLogTransform.position, this.transform.position) < 25.0f)))
            {
                whatIsTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
            if (GameObject.FindWithTag("coreTargetTag") == null)
            {
                Object.Destroy(gameObject);
            }

            if (GameObject.FindWithTag("Player") != null)
            {
                playerLogTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (GameObject.FindWithTag("Player") == null)
            {
                //Object.Destroy(gameObject);
            }
        }

        if ((Vector3.Distance(whatIsTarget.position, this.transform.position) < 25.0f))// && (Vector3.Distance(Player.position, this.transform.position) > 200.0f))
        {
            speed = 7f;
            transform.position -= transform.forward * speed * Time.deltaTime;
            transform.LookAt(new Vector3(whatIsTarget.position.x, transform.position.y, whatIsTarget.position.z));
            //transform.LookAt(Vector3(otherObject.position.x, transform.position.y, otherObject.position.z));
        }
        else if ((Vector3.Distance(whatIsTarget.position, this.transform.position) < 100.0f) && (Vector3.Distance(whatIsTarget.position, this.transform.position) > 35.0f))
        {
            speed = 4f;
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.LookAt(new Vector3(whatIsTarget.position.x, transform.position.y, whatIsTarget.position.z));

        }
        else
        {
            transform.LookAt(new Vector3(whatIsTarget.position.x, transform.position.y, whatIsTarget.position.z));
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
        if (Time.time > nextFire && (Vector3.Distance(whatIsTarget.position, transform.position) < enemyWeaponRange))
        {
            if (isRangedEnemy)
            {
                isShooting = true;
                nextFire = Time.time + fireRate;
                //canShootE_1 = false;
                //loadEnemyWeapon();
            }
        }
    }
    /**
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
    }*/
}