using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    public bool groundTouch;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            groundTouch = true;
        } else
        {
            groundTouch = false;
        }
    }
}
