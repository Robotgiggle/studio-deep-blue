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
    public GameObject effect;

    public Transform player;
    private AudioSource m_AudioSource;
    public AudioClip m_DeathSound;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            //"coreTargetTag"
            if (GameObject.FindWithTag("Player") != null)
            {
                player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        m_AudioSource = player.GetComponent<AudioSource>();

        tally = GameObject.Find("manager").GetComponent<WaveTally>();
        EnemyHealth += tally.wave * 4;
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
            if (isHitEffect != null)
            {

                //effect.GetComponent<ParticleSystem>().shape.radius = 5
                effect = Instantiate(isHitEffect, other.transform.position, this.transform.rotation);
                effect.transform.parent = this.transform;
            }
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
            playDeathSound();
            isDead = true;
            Destroy(transform.GetChild(2).gameObject);
            transform.GetChild(1).gameObject.layer = 4;
            GameObject.Find("DeathMenu").GetComponent<deathMenu>().kills++;
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
                dropPoint.y += 1.5f;
                Instantiate(token,dropPoint,transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void playDeathSound()
    {
        m_AudioSource.clip = m_DeathSound;
        m_AudioSource.Play();
    }
}