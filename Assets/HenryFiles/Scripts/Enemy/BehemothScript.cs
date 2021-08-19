using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemothScript : MonoBehaviour
{
    public Transform Player;
    public Transform core;
    public float speed = 4f;
    float actualSpeed;
    float nextAttack;
    public bool canAttack = true; //true;
    public bool isAttacking;
    Transform target;
    public float enemyAttackRange = 2.0f;
    public float sightRange;
    public GameObject meleeObject;
    public bool dead = false;
    Vector3 muzzle;
    int mask = 1 << 6;
    public float attackCooldown;
    public float attackDamage;
    float playerRange;
    float coreRange;

    // Teleport Variables
    public bool isTeleporting;
    public float timeToTeleport = 20f;

    // Start is called before the first frame update
    void Start()
    {
        playerRange = enemyAttackRange;
        coreRange = enemyAttackRange * 0.7f;
        if (Player == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }

        if (core == null)
        {
            if (GameObject.FindWithTag("coreTargetTag") != null)
            {
                core = GameObject.FindWithTag("coreTargetTag").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeToTeleport -= Time.deltaTime;
        if(timeToTeleport <= 0 && (Vector3.Distance(core.position, this.transform.position) > 35.0f))
        {
            target = Player;
            this.transform.position = new Vector3(Player.transform.position.x, Player.position.y + 20f, Player.position.z);
            isTeleporting = true;
            timeToTeleport = 20f;
        }
        else if (timeToTeleport <= 0 && (Vector3.Distance(core.position, this.transform.position) <= 35.0f))
        {
            target = Player;
            this.transform.position = new Vector3(Player.transform.position.x + Random.Range(7.0f, 15.0f), Player.position.y + 20f, Player.position.z);
            isTeleporting = true;
            timeToTeleport = 20f;
        }

        if(this.GetComponent<Rigidbody>().velocity.y == 0)
        {
            isTeleporting = false;
        }

        dead = GetComponent<Enemy_1_Health>().isDead;
        if(!dead){muzzle = transform.GetChild(2).position;}

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
        //if near the core, shrink sightRange
        if(Vector3.Distance(core.position,transform.position)<6.5f){sightRange = 8;}
        //select core or player as target
        if(Vector3.Distance(Player.position,transform.position)<sightRange){
            target = Player;
            enemyAttackRange = playerRange;
        }else{
            target = core;
            enemyAttackRange = coreRange;
        }
        //select whether to attack or move
        if ((Vector3.Distance(target.position, transform.position) > enemyAttackRange))
        {
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }
        //perform motion
        if ((Vector3.Distance(target.position, this.transform.position) < 1f) && dead == false)// && (Vector3.Distance(target.position, this.transform.position) > 200.0f))
        {
            speed = 1f;
            transform.position -= transform.forward * speed * Time.deltaTime;
            actualSpeed = speed * 0.75f;
            transform.position -= transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            actualSpeed = speed * 0.75f;
            transform.position -= transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            //transform.LookAt(Vector3(otherObject.position.x, transform.position.y, otherObject.position.z));
        }
        else if ((Vector3.Distance(target.position, this.transform.position) < 150.0f) && dead == false && (Vector3.Distance(target.position, this.transform.position) > enemyAttackRange))
        {
            speed = 1f;
            transform.position += transform.forward * speed * Time.deltaTime;
            actualSpeed = speed;
            transform.position += transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            actualSpeed = speed;
            transform.position += transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));

        }
        else if (isAttacking)
        {
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            actualSpeed = 0f;
        }

        if ((Vector3.Distance(Player.position, transform.position) > enemyAttackRange))
        if (!dead)
        {
            StartCoroutine(meleeAttack());
        }

        //transform.Rotate(new Vector3(0, -180, 0), Space.Self);
        //transform.eulerAngles = new Vector3(0, -transform.eulerAngles.y, 0);
        //transform.Rotate(new Vector3(-transform.eulerAngles.x, -0, 0), Space.Self);

        //Movement

        if (target == null)
            return;

        //float distance = Vector3.Distance(transform.position, target.position);

    }

    IEnumerator meleeAttack()
    {
        if (Time.time > nextAttack && canAttack == true && (Vector3.Distance(target.position, transform.position) < enemyAttackRange))
        {
            nextAttack = Time.time + attackCooldown;
            yield return new WaitForSeconds(attackCooldown-2.6f);
            RaycastHit hit;
            if (Physics.Raycast(muzzle,transform.forward,out hit,enemyAttackRange+0.7f, mask))
            {
                Debug.Log("hit the " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.name == "core")
                {
                    hit.transform.gameObject.GetComponent<CoreController>().health -= Mathf.FloorToInt(attackDamage); //bypass the core's iframes
                    if (gameObject.name == "Minion(Clone)")
                    {
                        Destroy(gameObject, 0.3f);
                    }
                }
                else if (hit.transform.gameObject.tag == "Player")
                {
                    hit.transform.gameObject.GetComponent<HealthScript>().healthPoints -= attackDamage;
                }
            }
            yield return new WaitForSeconds(2.6f);
        }
    }
}