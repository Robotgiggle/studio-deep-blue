using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float waveInterval = 20;
    GameObject player;
    WaveTally tally;
    bool peacetime;
    bool boss;
    float tBuffer;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tally = gameObject.GetComponent<WaveTally>(); 
        timer = waveInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>tBuffer&&peacetime){
            tBuffer++;
            timer--;
        }
        if(tally.wave>=2&&!boss){
            boss = true;
            StartCoroutine(GetComponent<BossSpawner>().spawnBoss());
        }
        if(tally.waveDone&&!peacetime){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
            if(enemies==null||enemies.Length==0){
                endWave();
            }
        }
        if(timer==0){
            if(tally.nextWave()){
                timer = waveInterval;
                peacetime = false;
            }
        }
    }

    void endWave(){
        tBuffer = Time.time + 1;
        peacetime = true;
        if(tally.waves.Length==tally.wave+1){
            Debug.Log("all waves completed");
            //end game
        }else{
            boss = false;
            Debug.Log("wave "+(tally.wave+1)+" completed");
            //send message to game UI to display "wave complete" text
            player.transform.GetChild(0).GetComponent<TokenManager>().reward();
        }
    }
}
