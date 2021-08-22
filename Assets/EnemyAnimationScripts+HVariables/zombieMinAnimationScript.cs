using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieMinAnimationScript : MonoBehaviour
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
        AnimCheck();
    }

    void AnimCheck()
    {
        zMinion.SetBool("isWalking", true);
        zMinion.SetBool("isAttacking", false);
        if (attack == true){zMinion.SetBool("isAttacking", true);}
        if (dead == true){zMinion.SetBool("isDead", true);}
    }
}
