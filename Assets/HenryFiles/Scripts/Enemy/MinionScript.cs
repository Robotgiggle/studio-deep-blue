using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 4f;
    float actualSpeed;
    public float nextAttack;
    public bool canAttack = true; //true;
    public bool isAttacking;
    public Transform target;
    public float enemyAttackRange = 2.0f;
    public GameObject meleeObject;
    public bool dead = false;

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
            actualSpeed = speed * 0.75f;
            transform.position -= transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            //transform.LookAt(Vector3(otherObject.position.x, transform.position.y, otherObject.position.z));
        }
        else if ((Vector3.Distance(Player.position, this.transform.position) < 100.0f) && dead == false && (Vector3.Distance(Player.position, this.transform.position) > 3.0f))
        {
            actualSpeed = speed;
            transform.position += transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));

        }
        else
        {
            transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
            actualSpeed = 0f;
        }
        //CheckIfTimeToAttack();


        if ((Vector3.Distance(Player.position, transform.position) > enemyAttackRange))
        {
            isAttacking = false;
            actualSpeed = speed;
        }
        else
        {
            isAttacking = true;
            actualSpeed = 0f;
        }
        //transform.Rotate(new Vector3(0, -180, 0), Space.Self);
        //transform.eulerAngles = new Vector3(0, -transform.eulerAngles.y, 0);
        //transform.Rotate(new Vector3(-transform.eulerAngles.x, -0, 0), Space.Self);

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