using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowbotAnimationScript : MonoBehaviour
{
    public Animator slowBot;
    public float speed = 0;
    public bool punch = false;
    public bool dead = false;

    void Start()
    {
        slowBot = GetComponent<Animator>();
    }
    
    void Update()
    {
        punch = GetComponentInParent<SlowRobotScript>().isAttacking;
        dead = GetComponentInParent<Enemy_1_Health>().isDead;
        AnimCheck();
    }

    void AnimCheck()
    {
        slowBot.SetBool("isMoving", true);
        slowBot.SetBool("isPunching", false);
        if (punch == true){slowBot.SetBool("isPunching", true);}
        if (dead == true){slowBot.SetBool("isDead", true);}
    }
}
