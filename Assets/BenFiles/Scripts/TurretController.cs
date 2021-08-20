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
    Vector3 direction;
    Vector3 target;
    float tbuffer;
    int displace = 1;
    // Start is called before the first frame update
    void Start()
    {
        tbuffer = reloadTime;
        if(this.name!="head_lv1"){
            transform.parent.GetComponent<TurretCollision>().health += 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        target = seekTarget(range);
        if(target!=Vector3.zero){
            transform.LookAt(target);
        }
        if(Time.time>=tbuffer&&target!=Vector3.zero){
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

    Vector3 seekTarget(float range){
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag("target");
        GameObject nearest = null;
        float maxDist = range;
        float dist;
        float vert;
        foreach(GameObject maybe in allTargets){
            dist = Vector3.Distance(transform.position,maybe.transform.position);
            vert = Mathf.Abs(maybe.transform.position.y - transform.position.y);
            if(dist<maxDist&&vert<=Mathf.Sin(0.383972f)*dist){
                nearest = maybe;
                maxDist = dist;
            }
        }
        if(nearest==null){return Vector3.zero;}
        Vector3 output = nearest.transform.position;
        if(range==10){
            output.y -= 0.4f;
        }else{
            output.y -= 0.5f;
        }
        return output;
    }

    public void levelUp(){
        Instantiate(head2,transform.position,transform.rotation,transform.parent);
        Destroy(this.gameObject);
    }

    public void takeDamage(int damage){
        transform.parent.GetComponent<TurretCollision>().health -= damage;
    }
    
    void OnCollisionEnter(Collision other){
        transform.parent.GetComponent<TurretCollision>().OnCollisionEnter(other);
    }

    void OnTriggerEnter(Collider other){
        transform.parent.GetComponent<TurretCollision>().OnTriggerEnter(other);
    }
}
