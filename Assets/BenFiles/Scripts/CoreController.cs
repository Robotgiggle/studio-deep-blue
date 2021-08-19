using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreController : MonoBehaviour
{
    public GameObject player;
    public Slider coreSlider;
    public int health;
    public int bulletDamage = 8;
    //public int weakDamage = 5;
    //public int strongDamage = 10;
    //public int bossDamage = 20;
    bool iframes = false;
    int tBuffer = 1;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        coreSlider.value = health;
        if(Time.time>tBuffer){
        	tBuffer++;
        	iframes = false;
        }
        if(health<=0){
        	//broadcast game over message to player controller
        }
    }

    public void takeDamage(int damage){
        if(!iframes){
            health -= damage;
            iframes = true;
        }
    }

    /*
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
    */

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("bullet")&&!iframes){
    		health -= bulletDamage;
    		iframes = true;
    		Destroy(other.gameObject);
    	}else if(other.gameObject.CompareTag("bullet")){
            Destroy(other.gameObject);
        }
    }
}
