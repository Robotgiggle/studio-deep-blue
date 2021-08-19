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
        //punch = get punch bool from Henry's behemoth enemy AI script
        //dead = get dead bool from Henry's behemoth enemy AI script
        //speed = get speed variable from Henry's behemoth enemy AI script
        punch = GetComponentInParent<BehemothScript>().isAttacking;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        speed = GetComponentInParent<BehemothScript>().speed;

        AnimCheck();
    }

    void AnimCheck()
    {
        if (speed > 0)
        {
            behBot.SetBool("isWalking", true);
        }
        else
        {
            behBot.SetBool("isWalking", false);
        }
        if (punch == true)
        {
            behBot.SetBool("isPunching", true);
        }
        else
        {
            behBot.SetBool("isPunching", false);
        }
        if (dead == true)
        {
            behBot.SetBool("isDead", true);
        }
        else
        {
            behBot.SetBool("isDead", false);
        }
    }
}
