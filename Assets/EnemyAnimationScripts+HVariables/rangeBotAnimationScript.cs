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
        backing = GetComponentInParent<RangeRobotScript>().playerTooClose;
        AnimCheck();
    }

    void AnimCheck()
    {
        rangeBot.SetBool("isWalking", true);
        rangeBot.SetBool("isShooting", false);
        if (shoot){rangeBot.SetBool("isShooting", true);}
        if (backing){rangeBot.SetBool("isShooting", false);}
        if (dead == true){rangeBot.SetBool("isDead", true);}
    }
}
