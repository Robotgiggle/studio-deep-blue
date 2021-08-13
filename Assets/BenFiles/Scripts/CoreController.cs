using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    public GameObject player;
    public int health = 100;
    public int bulletDamage = 8;
    public int weakDamage = 5;
    public int strongDamage = 10;
    public int bossDamage = 20;
    public float levelTimer = 120;
    bool iframes = false;
    int tBuffer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>tBuffer){
        	tBuffer++;
        	levelTimer--;
        	iframes = false;
        }
        if(health<=0){
        	//broadcast game over message to player controller
        }
        if(levelTimer<=0){
        	levelTimer = 0;
        	endLevel();
        }
    }

    void OnCollisionEnter(Collision other){
    	if(!iframes){
    		if(other.gameObject.CompareTag("weak")){
    			health -= weakDamage;
    		}else if(other.gameObject.CompareTag("strong")){
    			health -= strongDamage;
    		}else if(other.gameObject.CompareTag("boss")){
    			health -= bossDamage;
    		}
    		iframes = true;
    	}
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("bullet")&&!iframes){
    		health -= bulletDamage;
    		iframes = true;
    		Destroy(other.gameObject);
    	}
    }

    void endLevel(){
    	GameObject[] things = GameObject.FindGameObjectsWithTag("enemy");
    	for(int i=0;i<things.Length;i++){
    		Destroy(things[i]);
        }
        things = GameObject.FindGameObjectsWithTag("spawner");
        for(int i=0;i<things.Length;i++){
    		things[i].SetActive(false);
        }
    }
}
