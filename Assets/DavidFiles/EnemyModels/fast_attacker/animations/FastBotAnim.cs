using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBotAnim : MonoBehaviour
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
        //kick = get punch bool from Henry's slow enemy AI script
        //dead = get dead bool from Henry's slow enemy AI script
        //speed = get speed variable from Henry's slow enemy AI script
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