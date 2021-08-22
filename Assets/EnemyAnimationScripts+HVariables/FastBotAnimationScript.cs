using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBotAnimationScript : MonoBehaviour
{
    public Animator fastBot;
    public float speed = 0;
    public bool kick = false;
    public bool dead = false;

    void Start()
    {
        fastBot = GetComponent<Animator>();
    }

    void Update()
    {
        kick = GetComponentInParent<FastRobotScript>().isAttacking;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        AnimCheck();
    }

    void AnimCheck()
    {
        fastBot.SetBool("isWalking", true);
        fastBot.SetBool("isKicking", false);
        if (kick == true){fastBot.SetBool("isKicking", true);}
        if (dead == true){fastBot.SetBool("isDead", true);}
    }
}