using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRobotScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 4f;
    public float nextAttack;
    public bool canAttack = true; //true;
    public bool isAttacking;
    public Transform target;
    public float enemyAttackRange = 2.0f;
    public GameObject meleeObject;
    public bool dead = false;
    public bool enemyIsMelee = true;
    float tBuffer;
    Vector3 muzzle;
    public float stayBack;
    int mask = 1 << 6;
    public float attackCooldown;
    public float attackDamage;

    // Start is called before the first frame update
    void Start()
    {
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

        if ((Vector3.Distance(Player.position, this.transform.position) < 1f) && dead == false)// && (Vector3.Distance(Player.position, this.transform.position) > 200.0f))
        {
            speed = 3f;
            transform.position -= transform.forward * speed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            //transform.LookAt(Vector3(otherObject.position.x, transform.position.y, otherObject.position.z));
        }
        else if ((Vector3.Distance(Player.position, this.transform.position) < 100.0f) && dead == false && (Vector3.Distance(Player.position, this.transform.position) > 3.0f))
        {
            speed = 1f;
            transform.position += transform.forward * speed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));

        }
        else
        {
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            speed = 0f;
        }
        //CheckIfTimeToAttack();


        if ((Vector3.Distance(Player.position, transform.position) > enemyAttackRange))
        {
            isAttacking = false;
            speed = 1f;
        }
        else
        {
            isAttacking = true;
            speed = 0f;
        }

        if (enemyIsMelee)
        {
            
            RaycastHit hit;
            if (Physics.Raycast(muzzle, transform.forward, out hit, stayBack + 0.1f, mask) && Time.time >= tBuffer)
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
                    //damage player
                    hit.transform.gameObject.GetComponentInParent<HealthScript>().healthPoints -= 2;
                }
                tBuffer = Time.time + attackCooldown;
            }
        }
            //Movement

            if (target == null)
            return;

        //float distance = Vector3.Distance(transform.position, target.position);

    }

    void CheckIfTimeToAttack()
    {
        if (Time.time > nextAttack && canAttack == true && (Vector3.Distance(Player.position, transform.position) < enemyAttackRange))
        {
            //isAttacking = true;
            //meleeObject.SetActive(true);
            nextAttack = Time.time + 40;
            StartCoroutine(meleeEnd());

        }
        IEnumerator meleeEnd()
        {
            yield return new WaitForSeconds(2f);
            //isAttacking = false;
            //meleeObject.SetActive(false);
        }
    }
}
