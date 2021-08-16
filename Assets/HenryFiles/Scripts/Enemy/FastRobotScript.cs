using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastRobotScript : MonoBehaviour
{
    public Animation m_WAnimation;
    public Animation m_Walk;
    public Animation m_IAnimation;
    public Animation m_Idle;
    public Animation m_MAnimation;
    public Animation m_Melee;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayMAnimation()
    {
        if (m_Melee)
        {
            m_MAnimation = GetComponent<Animation>();
            m_MAnimation.Play();
        }
    }

    private void PlayWAnimation()
    {
        if (m_Walk)
        {
            m_WAnimation = GetComponent<Animation>();
            m_WAnimation.Play();
        }
    }
    private void PlayIAnimation()
    {
        if (m_Idle)
        {
            m_IAnimation = GetComponent<Animation>();
            m_IAnimation.Play();
        }
    }
}
