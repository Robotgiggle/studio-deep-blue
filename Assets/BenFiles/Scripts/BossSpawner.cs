using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;
    public float spawnDelay;
    RaycastHit spawnPoint;
    Vector3 spawnZone;
    int whichZone;
    // Start is called before the first frame update
    void Start()
    {
        spawnZone = new Vector3(65,45,65);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator spawnBoss()
    {
        yield return new WaitForSeconds(spawnDelay);
        whichZone = Random.Range(0,4);
        switch(whichZone){
            case 0:
                spawnZone.x *= -1;
                spawnZone.z *= -1;
                break;
            case 1:
                spawnZone.x *= -1;
                break;
            case 2:
                spawnZone.z *= -1;
                break;
        }
        Physics.Raycast(spawnZone,Vector3.down,out spawnPoint,50,8);
        Instantiate(boss, spawnPoint.point, transform.rotation);
    }
}
