using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject head2;
    public GameObject bullet;
    public float reloadTime;
    public float inaccuracy;
    public float range;
    Transform muzzle;
    Transform target;
    Vector3 direction;
    float tbuffer;
    int displace = 1;
    // Start is called before the first frame update
    void Start()
    {
        tbuffer = reloadTime;
        if(this.name!="head_lv1"){
            transform.parent.GetComponent<TurretCollision>().health += 7;
        }
    }

    // Update is called once per frame
    void Update()
    {
        target = seekTarget(range);
        if(target!=null){
            transform.LookAt(target);
        }
        transform.Rotate(2.7f,0,0);
        if(Time.time>=tbuffer){
            muzzle = transform.GetChild(1-displace);
            direction = transform.rotation.eulerAngles;
            direction.x += Random.Range(-inaccuracy,inaccuracy);
            direction.y += Random.Range(-inaccuracy,inaccuracy);
            direction.z += Random.Range(-inaccuracy,inaccuracy);
            Instantiate(bullet,muzzle.position,Quaternion.Euler(direction),transform);
            if(this.name!="head_lv1"){
                displace *= -1;
            }
            tbuffer = Time.time + reloadTime;
        }
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
        if(nearest==null){return null;}
        return nearest.transform;
    }

    void levelUp(){
        Instantiate(head2,transform.position,transform.rotation,transform.parent);
        Destroy(this.gameObject);
    }
    
    void OnCollisionEnter(Collision other){
        transform.parent.GetComponent<TurretCollision>().OnCollisionEnter(other);
    }

    void OnTriggerEnter(Collider other){
        transform.parent.GetComponent<TurretCollision>().OnTriggerEnter(other);
    }
}
