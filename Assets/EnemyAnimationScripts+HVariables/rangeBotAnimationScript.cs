using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeBotAnimationScript : MonoBehaviour
{
    public Animator rangeBot;
    public float speed = 0;
    public bool shoot = false;
    public bool dead = false;

    void Start()
    {
        rangeBot = GetComponent<Animator>();
    }

    void Update()
    {
        //shoot = get shoot bool from Henry's range enemy AI script
        //dead = get dead bool from Henry's range enemy AI script
        //speed = get speed variable from Henry's range enemy AI script
        shoot = GetComponentInParent<RangeRobotScript>().canShootE_1;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        speed = GetComponentInParent<RangeRobotScript>().speed;
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
        if (shoot == true)
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
