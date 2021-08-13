using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject head2;
    public float reloadTime;
    public float accuracy;
    public float range;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = seekTarget(range);
        transform.LookAt(target);
    }

    Transform seekTarget(float range){
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("enemy");
        GameObject nearest = null;
        float dist = range;
        foreach(GameObject maybe in allTargets){
            if(Vector3.Distance(transform.position,maybe.transform.position)<dist){
                nearest = maybe;
                dist = Vector3.Distance(transform.position,maybe.transform.position);
            }
        }
        return nearest.transform;
    }

    void levelUp(){
        Instantiate(head2,transform.parent);
        Destroy(this.gameObject);
    }
}
