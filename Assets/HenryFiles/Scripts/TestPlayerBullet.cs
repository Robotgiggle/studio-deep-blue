using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public float timer = 3f;
    public float speed = 5f;
    public GameObject explosionDamage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame 
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            if (hitEffect != null && explosionDamage != null)
            {
                Instantiate(hitEffect, transform.position, transform.rotation);
                Instantiate(explosionDamage, transform.position, transform.rotation);
            }
            this.gameObject.SetActive(false);
        }

        if (this.GetComponent<Transform>().rotation.y <= 90)
        {

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (hitEffect != null && explosionDamage != null)
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            Instantiate(explosionDamage, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hitEffect != null && explosionDamage != null)
        {
            Instantiate(hitEffect, transform.position, transform.rotation);
            Instantiate(explosionDamage, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}