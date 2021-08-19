using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject minion;
    public float spawnCooldown;
    RaycastHit spawnPoint;
    float tBuffer;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        tBuffer = spawnCooldown;   
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponentInParent<BehemothScript>().isTeleporting == false)
        if(Time.time>=tBuffer){
            angle = Random.Range(0f,359f);
            transform.Rotate(0,angle,0,Space.World);
            if(Physics.Raycast(transform.position,transform.forward,out spawnPoint,30)){
                Instantiate(minion,spawnPoint.point,transform.parent.rotation);
            }
            tBuffer = Time.time + spawnCooldown;
        }
    }
}
