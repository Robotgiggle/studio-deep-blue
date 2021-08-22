using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    public float damageToPlayer = 1.0f;
    public bool destroySelfOnImpact = false;    // variables dealing with exploding on impact (area of effect)
    public float delayBeforeDestroy = 0.0f;
    public GameObject explosionPrefab;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        lifeTime-=Time.deltaTime;
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}

