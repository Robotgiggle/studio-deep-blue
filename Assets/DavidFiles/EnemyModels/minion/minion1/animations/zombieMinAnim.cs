using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieMinAnim : MonoBehaviour
{
    public Animator zMinion;
    public float speed = 0;
    public bool attack = false;
    public bool dead = false;

    void Start()
    {
        zMinion = GetComponent<Animator>();
    }

    void Update()
    {
        attack = GetComponentInParent<MinionScript>().isAttacking;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        speed = GetComponentInParent<MinionScript>().speed;
        AnimCheck();
    }

    void AnimCheck()
    {
        if (speed > 0)
        {
            zMinion.SetBool("isWalking", true);
        }
        else
        {
            zMinion.SetBool("isWalking", false);
        }
        if (attack == true)
        {
            zMinion.SetBool("isAttacking", true);
        }
        else
        {
            zMinion.SetBool("isAttacking", false);
        }
        if (dead == true)
        {
            zMinion.SetBool("isDead", true);
        }
        else
        {
            zMinion.SetBool("isDead", false);
        }
    }
}
