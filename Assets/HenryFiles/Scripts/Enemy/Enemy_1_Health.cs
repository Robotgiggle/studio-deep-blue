using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Health : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject isHitEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void DeductPoints(int damageAmount)
    {
        // EnemyHealth -= damageAmount;
    }

    void OnCollisionEnter(Collision collision)
    {
        // EnemyHealth = EnemyHealth - 1;
        if (collision.gameObject.tag == "bullet")
        {


        }
    }

    void OnTriggerEnter(Collider other)
    {
        // EnemyHealth = EnemyHealth - 1;
        if (other.gameObject.tag == "bullet")
        {
            EnemyHealth = EnemyHealth - 1;
            Instantiate(isHitEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            //GlobalEnemies.CurrentEnemies -= 1;
            Destroy(this.gameObject);
            //SpawnGameObjects.NumberEnemies -= 1;
        }
    }
}