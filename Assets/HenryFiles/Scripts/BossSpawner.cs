using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject Boss;
    public float spawnDelay;
    GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator spawnBoss()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(Boss, transform.position, transform.rotation);
    }
}
