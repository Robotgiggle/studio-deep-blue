using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRobotScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 4f;
    float actualSpeed;
    float nextAttack;
    public bool canAttack = true; //true;
    public bool isAttacking;
    public Transform target;
    public float enemyAttackRange = 2.0f;
    public GameObject meleeObject;
    public bool dead = false;
    float tBuffer;
    Vector3 muzzle;
    int mask = 1 << 6;
    public float attackCooldown;
    public float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
        tBuffer = attackCooldown;
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

        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;

        if ((Vector3.Distance(Player.position, transform.position) > enemyAttackRange))
        {
            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }

        if ((Vector3.Distance(Player.position, this.transform.position) < 1f) && dead == false)// && (Vector3.Distance(Player.position, this.transform.position) > 200.0f))
        {
            actualSpeed = speed * 0.75f;
            transform.position -= transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            //transform.LookAt(Vector3(otherObject.position.x, transform.position.y, otherObject.position.z));
        }
        else if ((Vector3.Distance(Player.position, this.transform.position) < 100.0f) && dead == false && (Vector3.Distance(Player.position, this.transform.position) > enemyAttackRange))
        {
            actualSpeed = speed;
            transform.position += transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));

        }
        else if (isAttacking)
        {
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            actualSpeed = 0f;
        }


        if (!dead)
        {
            StartCoroutine(meleeAttack());
        }
            //Movement

            if (target == null)
            return;

        //float distance = Vector3.Distance(transform.position, target.position);

    }

    IEnumerator meleeAttack()
    {
        if (Time.time > nextAttack && canAttack == true && (Vector3.Distance(Player.position, transform.position) < enemyAttackRange))
        {
            nextAttack = Time.time + attackCooldown;
            yield return new WaitForSeconds(attackCooldown-0.9f);
            RaycastHit hit;
            if (Physics.Raycast(muzzle,transform.forward,out hit,enemyAttackRange+0.5f, mask))
            {
                Debug.Log("hit the " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.name == "core")
                {
                    hit.transform.gameObject.GetComponent<CoreController>().takeDamage(Mathf.FloorToInt(attackDamage));
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
            yield return new WaitForSeconds(0.9f);
        }
    }
}
