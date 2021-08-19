using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTally : MonoBehaviour
{
    public Vector3[] waves;
    public int wave = 0;
    public bool waveDone;
    Vector3[] backup;
    // Start is called before the first frame update
    void Start()
    {
        backup = waves;
        Debug.Log("started wave 1");
    }

    // Update is called once per frame
    void Update()
    {
        waveDone = (waves[wave].x==0&&waves[wave].y==0&&waves[wave].z==0);
    }

    public bool nextWave(){
        if(waves.Length>wave+1){
            wave++;
            SpawnerController[] spawners = Object.FindObjectsOfType<SpawnerController>(true);
            foreach(SpawnerController c in spawners){
                c.spawnRate *= 0.65f;
                c.gameObject.SetActive(true);
            }
            Debug.Log("started wave "+(wave+1));
            return true;
        }else{
            return false;
        }
    }

    void resetWaves(){
        waves = backup;
    }
}
