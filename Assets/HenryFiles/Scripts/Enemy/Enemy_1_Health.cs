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
        if (other.gameObject.tag == "friendlyBullet")
        {
            EnemyHealth--;
            //player bullet does more damage than turret bullet
            if(other.gameObject.name=="playerBullet(Clone)"){EnemyHealth--;}
            if(isHitEffect != null)
            Instantiate(isHitEffect, other.transform.position, other.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (EnemyHealth <= 0)
        {
            isDead = true;
            Destroy(transform.GetChild(2).gameObject);
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