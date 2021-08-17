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
        //kick = get kick bool from Henry's fast enemy AI script
        //dead = get dead bool from Henry's fast enemy AI script
        //speed = get speed variable from Henry's fast enemy AI script
        kick = GetComponentInParent<FastRobotScript>().isAttacking;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        speed = GetComponentInParent<FastRobotScript>().speed;

        AnimCheck();
    }

    void AnimCheck()
    {
        if (speed > 0)
        {
            fastBot.SetBool("isWalking", true);
        }
        else
        {
            fastBot.SetBool("isWalking", false);
        }
        if (kick == true)
        {
            fastBot.SetBool("isKicking", true);
        }
        else
        {
            fastBot.SetBool("isKicking", false);
        }
        if (dead == true)
        {
            fastBot.SetBool("isDead", true);
        }
        else
        {
            fastBot.SetBool("isDead", false);
        }
    }
}