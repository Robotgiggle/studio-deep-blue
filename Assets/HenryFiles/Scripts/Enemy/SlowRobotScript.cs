using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRobotScript : MonoBehaviour
{
    public Animation m_WAnimation;
    public Animation m_Walk;
    public Animation m_IAnimation;
    public Animation m_Idle;
    public Animation m_MAnimation;
    public Animation m_Melee;
    public Transform Player;
    public float speed = 4f;
    public float nextAttack;
    public bool canAttack = true;
    public Transform target;
    public float enemyAttackRange = 7.0f;

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
            transform.position -= transform.forward * (1 / 10) * speed * Time.deltaTime;
            if (m_Walk)
            {
                m_WAnimation = GetComponent<Animation>();
                m_WAnimation.Play();
            }
        }
        else if ((Vector3.Distance(Player.position, this.transform.position) < 10.0f) && (Vector3.Distance(Player.position, this.transform.position) > 0.0f))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            if (m_Walk)
            {
                m_WAnimation = GetComponent<Animation>();
                m_WAnimation.Play();
            }
        }
        else
        {
            if (m_Idle)
            {
                m_IAnimation = GetComponent<Animation>();
                m_IAnimation.Play();
            }
        }

        transform.LookAt(Player.position);
        CheckIfTimeToAttack();

        transform.Rotate(new Vector3(0, -180, 0), Space.Self);
        //transform.eulerAngles = new Vector3(0, -transform.eulerAngles.y, 0);
        transform.Rotate(new Vector3(-transform.eulerAngles.x, -0, 0), Space.Self);

        //Movement

        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

    }

    void CheckIfTimeToAttack()
    {
        if (Time.time > nextAttack && canAttack == true && (Vector3.Distance(Player.position, transform.position) < enemyAttackRange))
        {

                nextAttack = Time.time + 4;            
        }
    }

    private void PlayMAnimation()
    {
        if (m_Melee)
        {
            m_MAnimation = GetComponent<Animation>();
            m_MAnimation.Play();
        }
    }

    private void PlayWAnimation()
    {
        if (m_Walk)
        {
            m_WAnimation = GetComponent<Animation>();
            m_WAnimation.Play();
        }
    }
    private void PlayIAnimation()
    {
        if (m_Idle)
        {
            m_IAnimation = GetComponent<Animation>();
            m_IAnimation.Play();
        }
    }
}
