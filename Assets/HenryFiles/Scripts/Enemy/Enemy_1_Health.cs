using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Health : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject isHitEffect;
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
            EnemyHealth = EnemyHealth - 1;
            if(isHitEffect != null)
            Instantiate(isHitEffect, other.transform.position, other.transform.rotation);
            //Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /**
        if (EnemyHealth <= 0 && m_Death.isPlaying == false)
        {
            m_Animation = GetComponent<Animation>();
            m_Animation.Play();
            //GlobalEnemies.CurrentEnemies -= 1;
            //Destroy(this.gameObject);
            //SpawnGameObjects.NumberEnemies -= 1;
        }

        if(m_Death.isPlaying == false)
        {
            hasPlayed = true;
        }

        if(EnemyHealth <= 0 && hasPlayed == true)
        {
            Destroy(this.gameObject);
        }*/
    }
}