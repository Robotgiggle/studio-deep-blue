using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeBotAnimationScript : MonoBehaviour
{
    public Animator rangeBot;
    public float speed = 0;
    public bool shoot = false;
    public bool dead = false;
    public bool doWalking = false;

    void Start()
    {
        rangeBot = GetComponent<Animator>();
    }

    void Update()
    {
        //shoot = get shoot bool from Henry's range enemy AI script
        //dead = get dead bool from Henry's range enemy AI script
        //speed = get speed variable from Henry's range enemy AI script
        shoot = GetComponentInParent<RangeRobotScript>().isShooting;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        speed = GetComponentInParent<RangeRobotScript>().speed;
        //doWalking = GetComponentInParent<RangeRobotScript>().doWalkingAnimation;
        AnimCheck();
    }

    void AnimCheck()
    {
        if (speed > 0 || doWalking)
        {
            rangeBot.SetBool("isWalking", true);
        }
        else if(!doWalking)
        {
            rangeBot.SetBool("isWalking", false);
        }
        if (shoot == true && !doWalking)
        {
            rangeBot.SetBool("isShooting", true);
        }
        else
        {
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
