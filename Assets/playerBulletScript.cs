using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletScript : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public GameObject effect;
    //public Transform spawnSource;

    void Start()
    {
        /*
        if (spawnSource == null)
        {
            if (GameObject.FindWithTag("playerBulletSpawner") != null)
            {
                spawnSource = GameObject.FindWithTag("playerBulletSpawner").GetComponent<Transform>();
            }
        }
        this.transform.position = spawnSource.transform.position;
        this.transform.rotation = spawnSource.transform.rotation;
        */
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider col)
    {
        //if (other.gameObject.CompareTag("enemy"))
        //{
        //    Destroy(this.gameObject);
        //}
        //if (other.gameObject.CompareTag("<wall>"))
        //{
        //    Destroy(this.gameObject);
        //}
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("NeverMind");
        }
        else
        {
            Destroy(this.gameObject);
        }
        if(effect != null)
        {
            Instantiate(effect, transform.position, transform.rotation);
        }
    }
}
