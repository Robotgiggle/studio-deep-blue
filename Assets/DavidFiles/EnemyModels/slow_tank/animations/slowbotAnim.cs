using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowbotAnim : MonoBehaviour
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
        AnimCheck();
        //speed = get speed variable from Henry's enemy AI script
    }

    void AnimCheck()
    {
        if (speed > 0)
        {
            slowBot.SetBool("isMoving", true);
        } else
        {
            slowBot.SetBool("isMoving", false);
        }
        if (punch == true)
        {
            slowBot.SetBool("isPunching", true);
        }
        else
        {
            slowBot.SetBool("isPunching", false);
        }
        if (dead == true)
        {
            slowBot.SetBool("isDead", true);
        }
        else
        {
            slowBot.SetBool("isDead", false);
        }
    }
}
