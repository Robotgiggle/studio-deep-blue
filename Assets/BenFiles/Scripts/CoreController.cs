using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreController : MonoBehaviour
{
    public int health;
    public int bulletDamage = 4;
    HealthScript player;
    bool iframes = false;
    Slider coreSlider;
    int tBuffer = 1;
    public GameObject hitEffect;
    public GameObject destroyedEffect;
    public bool effectHasSpawned;
    public GameObject coreModel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<HealthScript>();
        coreSlider = GameObject.Find("CoreSlider").GetComponent<Slider>();
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
            if (!effectHasSpawned)
            {
                effectHasSpawned = true;
                Instantiate(destroyedEffect, this.transform.position, this.transform.rotation);
            }
            StartCoroutine(coreDeath());
        }

        IEnumerator coreDeath()
        {
            yield return new WaitForSeconds(1f);
            player.coreDeath = true;
            player.healthPoints = 0;
            coreModel.SetActive(false);
        }
    }

    public bool takeDamage(int damage){
        if(!iframes){
            health -= damage;
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            iframes = true;
        }
        if(health<=0){
            return true;
        }else{
            return false;
        }
    }

    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("bullet")&&!iframes){
    		health -= bulletDamage;
            Instantiate(hitEffect, this.transform.position, this.transform.rotation);
            iframes = true;
    		Destroy(other.gameObject);
            if(health<=0){
                player.killedBy = "by RK-49 \"Ranger\"";
            }
    	}else if(other.gameObject.CompareTag("bullet")){
            Destroy(other.gameObject);
        }
    }
}
