using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimScript : MonoBehaviour
{
    public Animator Anim;
    public int gunLevel;

    void Start()
    {
        Anim = GetComponent<Animator>();    
    }
    
    void Update()
    {
        //gunLevel = player's gun level; (import from another script)
        AnimCheck();
    }

    void AnimCheck()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            Anim.SetBool("front", true);
        } else
        {
            Anim.SetBool("front", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Anim.SetBool("left", true);
        }
        else
        {
            Anim.SetBool("left", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Anim.SetBool("right", true);
        }
        else
        {
            Anim.SetBool("right", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) && gunLevel == 1)
        {
            Anim.SetBool("pistol", true);
        }
        else
        {
            Anim.SetBool("pistol", false);
        }
        if (Input.GetKey(KeyCode.Mouse0) && gunLevel == 2)
        {
            Anim.SetBool("ar", true);
        }
        else
        {
            Anim.SetBool("ar", false);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Anim.SetBool("throw", true);
        }
        else
        {
            Anim.SetBool("throw", false);
        }
    }
}
