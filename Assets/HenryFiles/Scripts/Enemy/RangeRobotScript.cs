using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRobotScript : MonoBehaviour
{

    //public GameObject bullet;
    public Transform whatIsTarget;
    public Transform playerLogTransform;
    public bool isShooting;
    public float enemyWeaponRange = 15.0f;
    public float speed = 4f;
    float actualSpeed;
    public float distanceToPlayer;
    public bool dead = false;
    public bool enemyIsInRange;
    public bool playerTooClose;
    WaveTally tally;


    // Start is called before the first frame update
    void Start()
    {
        tally = GameObject.Find("manager").GetComponent<WaveTally>();
        speed += tally.wave * 0.3f;
        transform.GetChild(3).gameObject.GetComponent<EBulletSpawner>().inaccuracy -= tally.wave;
        // if no target specified, assume the player
        if (whatIsTarget == null)
        {
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
        distanceToPlayer = (Vector3.Distance(playerLogTransform.position, this.transform.position));
        dead = GetComponent<Enemy_1_Health>().isDead;
        if ((Vector3.Distance(whatIsTarget.position, this.transform.position) <= enemyWeaponRange))
        {
            enemyIsInRange = true;
        }
        else
        {
            enemyIsInRange = false;
        }

        if ((distanceToPlayer <= enemyWeaponRange - 2))
        {
            playerTooClose = true;
        }
        else
        {
            playerTooClose = false;
        }

        if (whatIsTarget == null)
        {
            if ((distanceToPlayer > enemyWeaponRange+3f))
            {
                whatIsTarget = GameObject.FindWithTag("coreTargetTag").GetComponent<Transform>();
            }
            else if (distanceToPlayer < enemyWeaponRange+3f)
            {
                whatIsTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (GameObject.FindWithTag("Player") != null)
            {
                playerLogTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }

        if (whatIsTarget != null)
        {
            if ((distanceToPlayer > enemyWeaponRange+4f))
            {
                whatIsTarget = GameObject.FindWithTag("coreTargetTag").GetComponent<Transform>();
            }
            else if (distanceToPlayer < enemyWeaponRange+4f)
            {
                whatIsTarget = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }

            if (GameObject.FindWithTag("Player") != null)
            {
                playerLogTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }

        if (dead == false && playerTooClose)
        {
            actualSpeed = speed * 0.75f;
            transform.position -= transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(playerLogTransform.position.x, transform.position.y, playerLogTransform.position.z));
        }
        else if ((Vector3.Distance(whatIsTarget.position, this.transform.position) < 150.0f) && dead == false && !enemyIsInRange && !playerTooClose)
        {
            actualSpeed = speed;
            transform.position += transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(whatIsTarget.position.x, transform.position.y, whatIsTarget.position.z));
        }
        else
        {
            transform.LookAt(new Vector3(whatIsTarget.position.x, transform.position.y, whatIsTarget.position.z));
            actualSpeed = 0f;
        }

    }

}