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
    WaveTally tally;
    float spread;
    // Start is called before the first frame update
    void Start()
    {
        tally = GameObject.Find("manager").GetComponent<WaveTally>();
        if(gameObject.layer=="UI"||gameObject.layer=="Ignore Raycast"){
            EnemyHealth += tally.wave * 2;
        }else{
            EnemyHealth += tally.wave * 6;
        }
        
        if(EnemyHealth>75){
            spread = 0.9f;
        }else{
            spread = 0.5f;
        }
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
        if (transform.position.y<0){
            Destroy(gameObject);
        }
        if (EnemyHealth <= 0&&!isDead)
        {
            isDead = true;
            Destroy(transform.GetChild(2).gameObject);
            StartCoroutine(despawn());

        }

        IEnumerator despawn()
        {
            yield return new WaitForSeconds(2.5f);
            if (deathEffect != null)
            Instantiate(deathEffect, this.transform.position, this.transform.rotation);
            TokensDropped += Random.Range(-1,2);
            for(int i=0;i<TokensDropped;i++){
                Vector3 dropPoint = transform.position;
                dropPoint.x += Random.Range(-spread,spread);
                dropPoint.z += Random.Range(-spread,spread);
                dropPoint.y++;
                Instantiate(token,dropPoint,transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}