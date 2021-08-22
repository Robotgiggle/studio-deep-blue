using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    void Start()
    {

    }

    void Update()
    {
        lifeTime-=Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
