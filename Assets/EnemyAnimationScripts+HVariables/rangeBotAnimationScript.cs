using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeBotAnimationScript : MonoBehaviour
{
    public Animator rangeBot;
    public float speed = 0;
    public bool shoot = false;
    public bool dead = false;
    public bool backing = false;

    void Start()
    {
        rangeBot = GetComponent<Animator>();
    }

    void Update()
    {
        shoot = GetComponentInParent<RangeRobotScript>().enemyIsInRange;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        speed = GetComponentInParent<RangeRobotScript>().speed;
        backing = GetComponentInParent<RangeRobotScript>().playerTooClose;
        AnimCheck();
    }

    void AnimCheck()
    {
        if (speed > 0)
        {
            rangeBot.SetBool("isWalking", true);
        }
        else
        {
            rangeBot.SetBool("isWalking", false);
        }

        if (shoot)
        {
            rangeBot.SetBool("isShooting", true);
        }
        else
        {
            rangeBot.SetBool("isShooting", false);
        }

        if (backing)
        {
            rangeBot.SetBool("isWalking", true);
            rangeBot.SetBool("isShooting", false);
        }

        if (dead == true)
        {
            rangeBot.SetBool("isDead", true);
        }
        else
        {
            rangeBot.SetBool("isDead", false);
        }
    }
}
