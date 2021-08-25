using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehemothScript : MonoBehaviour
{
    public Transform Player;
    public Transform core;
    public float speed = 4f;
    float actualSpeed;
    float nextAttack;
    public bool canAttack = true;
    public bool isAttacking;
    Transform target;
    public float enemyAttackRange = 2.0f;
    public float sightRange;
    public bool dead = false;
    Vector3 muzzle;
    int mask = 1 << 6;
    public float attackCooldown;
    public float attackDamage;
    float playerRange;
    float coreRange;
    WaveTally tally;

    // Teleport Variables
    public bool isTeleporting;
    public float timeToTeleport = 20f;
    public float airToGroundTimer = 2f;
    public GameObject teleportEffect;
    public GameObject teleportEffectPoint;
    public AudioClip teleportSound;
    public AudioClip teleportWarning;
    public Transform emergencyTeleportPointl;
    public Transform emergencyTeleportPoint2;
    public Transform emergencyTeleportPoint3;
    public Transform emergencyTeleportPoint4;
    public int teleportPoint;

    private AudioSource m_AudioSource;
    public AudioClip m_attackSound;
    // Start is called before the first frame update
    void Start()
    {
        emergencyTeleportPointl = GameObject.Find("TP1").GetComponent<Transform>();
        emergencyTeleportPoint2 = GameObject.Find("TP2").GetComponent<Transform>();
        emergencyTeleportPoint3 = GameObject.Find("TP3").GetComponent<Transform>();
        emergencyTeleportPoint4 = GameObject.Find("TP4").GetComponent<Transform>();

        playerRange = enemyAttackRange;
        coreRange = enemyAttackRange * 0.7f;
        tally = GameObject.Find("manager").GetComponent<WaveTally>();
        speed += tally.wave * 0.3f;
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
        m_AudioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timeToTeleport -= Time.deltaTime;
        if(timeToTeleport <= 0)
        {
            Instantiate(teleportEffect, teleportEffectPoint.transform.position, teleportEffectPoint.transform.rotation);
            StartCoroutine(teleport());

        }

        IEnumerator teleport()
        {
            yield return new WaitForSeconds(0.5f);
            if (timeToTeleport <= 0 && (Vector3.Distance(core.position, this.transform.position) > 10.0f))
            {
                airToGroundTimer = 2f;
                target = Player;
                this.transform.position = new Vector3(Player.transform.position.x, Player.position.y + 20f, Player.position.z);
                Instantiate(teleportEffect, teleportEffectPoint.transform.position, teleportEffectPoint.transform.rotation);
                isTeleporting = true;
                timeToTeleport = 20f;
            }
            else if (timeToTeleport <= 0 && (Vector3.Distance(core.position, this.transform.position) <= 15.0f))
            {
                airToGroundTimer = 2f;
                target = Player;

                teleportPoint = Random.Range(1, 5);
                if (teleportPoint == 1)
                {
                    this.transform.position = emergencyTeleportPointl.transform.position;
                    
                }
                else if(teleportPoint == 2)
                {
                    this.transform.position = emergencyTeleportPoint2.transform.position;

                }
                else if (teleportPoint == 3)
                {
                    this.transform.position = emergencyTeleportPoint3.transform.position;

                }
                else if (teleportPoint == 4)
                {
                    this.transform.position = emergencyTeleportPoint4.transform.position;

                }
                Instantiate(teleportEffect, teleportEffectPoint.transform.position, teleportEffectPoint.transform.rotation);
                isTeleporting = true;
                timeToTeleport = 20f;
            }

        }

        if(isTeleporting)
        {
            airToGroundTimer -= Time.deltaTime;
            if (Vector3.Distance(core.position, this.transform.position) <= 10.0f)
            {
                timeToTeleport = 1f;
            }
        }

        if(airToGroundTimer <= 0)
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
        if(Vector3.Distance(core.position,transform.position)<6.5f){sightRange = 11;}
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
        if ((Vector3.Distance(target.position, this.transform.position) < 1f) && dead == false)
        {
            actualSpeed = speed * 0.75f;
            transform.position -= transform.forward * actualSpeed * Time.deltaTime;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        }
        else if ((Vector3.Distance(target.position, this.transform.position) < 150.0f) && dead == false && (Vector3.Distance(target.position, this.transform.position) > enemyAttackRange))
        {
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

    }

    void playShootSound()
    {
        m_AudioSource.clip = m_attackSound;
        m_AudioSource.Play();
    }

    IEnumerator meleeAttack()
    {
        if (Time.time > nextAttack && canAttack == true && (Vector3.Distance(target.position, transform.position) < enemyAttackRange))
        {
            nextAttack = Time.time + attackCooldown;
            yield return new WaitForSeconds(attackCooldown-2.6f);
            RaycastHit hit;
            playShootSound();
            if (Physics.Raycast(muzzle,transform.forward,out hit,enemyAttackRange+0.7f, mask))
            {
                Debug.Log("hit the " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.name == "core")
                {
                    CoreController c = hit.transform.gameObject.GetComponent<CoreController>();
                    c.health -= Mathf.FloorToInt(attackDamage); //bypass the core's iframes
                    if(c.health<=0){
                        Player.gameObject.GetComponent<HealthScript>().killedBy = "by ZL-81 \"Strongman\"";
                    }
                }
                else if (hit.transform.gameObject.tag == "Player")
                {
                    HealthScript h = hit.transform.gameObject.GetComponent<HealthScript>();
                    if(h.ApplyDamage(attackDamage)){
                        h.killedBy = "by ZL-81 \"Strongman\"";
                    }
                }
            }
            yield return new WaitForSeconds(2.6f);
        }
    }
}