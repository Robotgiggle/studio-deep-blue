using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Health : MonoBehaviour
{
    public int EnemyHealth = 4;
    public GameObject isHitEffect;
    public GameObject deathEffect;
    public bool hasPlayed = false;
    public bool isDead;
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
        if (other.gameObject.tag == "friendlyBullet")
        {
            EnemyHealth = EnemyHealth - 2;
            if(isHitEffect != null)
            Instantiate(isHitEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (EnemyHealth <= 0)
        {
            isDead = true;
            StartCoroutine(despawn());

        }

        IEnumerator despawn()
        {
            yield return new WaitForSeconds(5f);
            if (deathEffect != null)
            Instantiate(deathEffect, this.transform.position, this.transform.rotation);

            Destroy(gameObject);
        }
    }
}