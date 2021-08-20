using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollision : MonoBehaviour
{
    public int health = 20;
    public int bulletDamage = 8;
    public int weakDamage = 5;
    public int strongDamage = 10;
    public int bossDamage = 20;
    float tbuffer;
    bool iframes = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=tbuffer){iframes = false;}
        if(health<=0){
            //death animation?
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage){
        health -= damage;
    }

    public void OnCollisionEnter(Collision other){
        if(!iframes){
            if(other.gameObject.CompareTag("weak")){
                health -= weakDamage;
            }else if(other.gameObject.CompareTag("strong")){
                health -= strongDamage;
            }else if(other.gameObject.CompareTag("boss")){
                health -= bossDamage;
            }
            iframes = true;
            tbuffer = Time.time + 1;
        }
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("bullet")&&!iframes){
            health -= bulletDamage;
            iframes = true;
            Destroy(other.gameObject);
        }
    }
}
