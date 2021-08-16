using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionScript : MonoBehaviour
{
    public Animation m_Animation;
    public Animation m_animation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayAnimation()
    {
        if (m_animation)
        {
            m_Animation = GetComponent<Animation>();
            m_Animation.Play();
        }
    }
}