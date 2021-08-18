using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyToken : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,20f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed,0);
    }
}
