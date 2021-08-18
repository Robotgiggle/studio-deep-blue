using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject projectile;
    public float attackCooldown;
    public float attackDamage;
    public float attackHeight;
    public float sightRadius;
    public float stayBack;
    public float speed;
    public bool ranged;
    GameObject player;
    GameObject core;
    Vector3 muzzle;
    Vector3 target;
    float tBuffer;
    int mask = 1 << 6;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        core = GameObject.Find("coreTarget");
        tBuffer = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        muzzle = transform.position;
        muzzle.y += attackHeight;
        //reduce distraction-by-player radius if enemy is near the core
        if(Vector3.Distance(transform.position,core.transform.position)<=stayBack+2){
            sightRadius = 3;
        }
        //select target and move towards it
        if(Vector3.Distance(transform.position,player.transform.position)<=sightRadius){
            target = player.transform.position;
        }else{
            target = core.transform.position;
        }
        target.y = transform.position.y;
        transform.LookAt(target);
        if(Vector3.Distance(transform.position,target)>stayBack){
            transform.Translate(Vector3.forward*speed*Time.deltaTime);
        }
        //attack target
        if(ranged){
            if(Vector3.Distance(transform.position,target)<=stayBack+0.6&&Time.time>=tBuffer){
                Quaternion shotDirection;
                if(Vector3.Distance(transform.position,player.transform.position)<=sightRadius){
                    shotDirection = Quaternion.LookRotation((player.transform.position-transform.position),Vector3.up);
                }else{
                    shotDirection = Quaternion.LookRotation((core.transform.position-transform.position),Vector3.up);
                }
                Instantiate(projectile,muzzle,shotDirection);
                tBuffer = Time.time + attackCooldown;
            }
        }else{
            RaycastHit hit;
            if(Physics.Raycast(muzzle,transform.forward,out hit,stayBack+0.1f,mask)&&Time.time>=tBuffer){
                Debug.Log("hit the "+hit.transform.gameObject.name);
                if(hit.transform.gameObject.name=="core"){
                    hit.transform.gameObject.GetComponent<CoreController>().takeDamage(Mathf.FloorToInt(attackDamage));
                    if(gameObject.name=="Minion(Clone)"){
                        Destroy(gameObject,0.3f);
                    }
                }else if(hit.transform.gameObject.tag=="Player"){
                    //damage player
                }
                tBuffer = Time.time + attackCooldown;
            }
        }
    }
}
