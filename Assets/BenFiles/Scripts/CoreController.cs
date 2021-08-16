using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreController : MonoBehaviour
{
    public GameObject player;
    public float waveInterval = 20;
    public int health = 100;
    public int bulletDamage = 8;
    public int weakDamage = 5;
    public int strongDamage = 10;
    public int bossDamage = 20;
    float levelTimer = 240;
    bool peacetime = false;
    bool iframes = false;
    WaveTally tally;
    int tBuffer = 1;
    // Start is called before the first frame update
    void Start()
    {
        tally = gameObject.GetComponent<WaveTally>();       
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
        if(!tally.endless&&tally.waveDone&&!peacetime){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            if(enemies==null||enemies.Length==0){
                endWave();
            }else{
                levelTimer = waveInterval;
            }
        }else if(!tally.endless&&!peacetime){
            levelTimer = waveInterval;
        }
        if(levelTimer==0){
            if(tally.endless){
                endLevel();
            }else{
                if(tally.nextWave()){
                    peacetime = false;
                }
            }
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

    void endWave(){
        peacetime = true;
        if(tally.waves.Length==tally.wave+1){
            Debug.Log("all waves completed");
            //end game
        }else{
            Debug.Log("wave "+(tally.wave+1)+" completed");
            //send message to game UI to display "wave complete" text
            //increase player's energy tokens by a flat amount
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
