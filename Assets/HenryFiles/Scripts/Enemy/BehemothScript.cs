using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemothScript : MonoBehaviour
{
    public Transform Player;
    public float speed = 4f;
    public float nextAttack;
    public bool canAttack = true;
    public bool isAttacking = true;
    public Transform target;
    public float enemyAttackRange = 7.0f;
    public GameObject meleeObject;

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

        if ((Vector3.Distance(Player.position, this.transform.position) < 70.0f) && (Vector3.Distance(Player.position, this.transform.position) > 10.0f))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        else if ((Vector3.Distance(Player.position, this.transform.position) < 10.0f) && (Vector3.Distance(Player.position, this.transform.position) > 0.0f))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        transform.LookAt(Player.position);
        CheckIfTimeToAttack();

        //transform.Rotate(new Vector3(0, -180, 0), Space.Self);
        //transform.eulerAngles = new Vector3(0, -transform.eulerAngles.y, 0);
        //transform.Rotate(new Vector3(-transform.eulerAngles.x, -0, 0), Space.Self);

        //Movement

        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

    }

    void CheckIfTimeToAttack()
    {
        if (Time.time > nextAttack && canAttack == true && (Vector3.Distance(Player.position, transform.position) < enemyAttackRange))
        {
            isAttacking = true;
            meleeObject.SetActive(true);
            nextAttack = Time.time + 4;
            StartCoroutine(meleeEnd());
        }
    }

    IEnumerator meleeEnd()
    {
        yield return new WaitForSeconds(2f);
        meleeObject.SetActive(false);
    }
}