using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeRobotScript : MonoBehaviour
{
    public Animation m_WAnimation;
    public Animation m_Walk;
    public Animation m_IAnimation;
    public Animation m_Idle;

    public GameObject bullet;
    public float fireRate = 7;
    public float nextFire;
    public Transform Player;
    public Transform rightGun;
    public Transform leftGun;
    public bool isRangedEnemy;
    public bool canShootE_1 = true;
    public float enemyWeaponRange = 90.0f;
    public float BulletForwardForce = 5;
    public float speed = 4f;
    public float minDist = 1f;
    public Transform target;
    public float enemyRange = 40;

    // Start is called before the first frame update
    void Start()
    {
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
        CheckIfTimeToFire();

        transform.Rotate(new Vector3(0, -180, 0), Space.Self);
        //transform.eulerAngles = new Vector3(0, -transform.eulerAngles.y, 0);
        transform.Rotate(new Vector3(-transform.eulerAngles.x, -0, 0), Space.Self);

        //Movement

        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

    }

    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire && canShootE_1 == true && (Vector3.Distance(Player.position, transform.position) < enemyWeaponRange))
        {

            if (bullet != null && isRangedEnemy)
            {
                Instantiate(bullet, rightGun.transform.position, rightGun.transform.rotation);
                Instantiate(bullet, leftGun.transform.position, leftGun.transform.rotation);

                nextFire = Time.time + 4;

                loadEnemyWeapon();
            }
        }
    }

    void loadEnemyWeapon()
    {
        if (Time.time > nextFire)
        {
            //   canShootE_1 = true;
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
        if (m_Walk)
        {
            m_WAnimation = GetComponent<Animation>();
            m_WAnimation.Play();
        }
    }
}