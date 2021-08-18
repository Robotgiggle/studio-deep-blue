using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        lifeTime-=Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        //if (other.gameObject.CompareTag("<wall>"))
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
