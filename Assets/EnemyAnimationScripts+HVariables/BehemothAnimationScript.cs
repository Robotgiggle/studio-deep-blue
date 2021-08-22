using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehemothAnimationScript : MonoBehaviour
{
    public Animator behBot;
    public float speed = 0;
    public bool punch = false;
    public bool dead = false;

    void Start()
    {
        behBot = GetComponent<Animator>();
    }

    void Update()
    {
        punch = GetComponentInParent<BehemothScript>().isAttacking;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        AnimCheck();
    }

    void AnimCheck()
    {
        behBot.SetBool("isWalking", true);
        behBot.SetBool("isPunching", false);
        if (punch == true){behBot.SetBool("isPunching", true);}
        if (dead == true){behBot.SetBool("isDead", true);}
    }
}
