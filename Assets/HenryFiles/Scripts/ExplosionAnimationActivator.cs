using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationActivator : MonoBehaviour
{
    public bool Detonate = false;
    Animator _animator;
    public float lifetime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        Detonate = true;

        if(Detonate)
        {
            lifetime -= Time.deltaTime;
        }

        if(lifetime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
