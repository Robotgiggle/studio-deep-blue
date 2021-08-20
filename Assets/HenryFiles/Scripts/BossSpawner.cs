using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss;
    public GameObject wave;
    public bool hasSpawned;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if(wave.GetComponent<WaveTally>().signal == true && hasSpawned = false)
        {
            spawnBoss();
        }
    }

    void spawnBoss()
    {
        Instantiate(Boss, transform.position, transform.rotation);
        hasSpawned = true;
    }
}
