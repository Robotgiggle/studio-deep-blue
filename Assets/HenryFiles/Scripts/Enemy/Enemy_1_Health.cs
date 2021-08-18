using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Health : MonoBehaviour
{
    public int EnemyHealth = 4;
    public int TokensDropped;
    public GameObject isHitEffect;
    public GameObject deathEffect;
    public GameObject token;
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
            EnemyHealth -= 2;
            if(isHitEffect != null)
            Instantiate(isHitEffect, other.transform.position, other.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (EnemyHealth <= 0&&!isDead)
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
            TokensDropped += Random.Range(-1,2);
            for(int i=0;i<TokensDropped;i++){
                Vector3 dropPoint = transform.position;
                dropPoint.x += Random.Range(-0.5f,0.5f);
                dropPoint.z += Random.Range(-0.5f,0.5f);
                Instantiate(token,dropPoint,transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}