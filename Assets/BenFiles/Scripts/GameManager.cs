using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float waveInterval = 20;
    public float timer;
    public bool win;
    WaveAnnouncer announcer;
    GameObject player;
    WaveTally tally;
    bool peacetime;
    bool boss;
    float tBuffer;
    // Start is called before the first frame update
    void Start()
    {
        announcer = GameObject.Find("Announcer").GetComponent<WaveAnnouncer>();
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
        StartCoroutine(announcer.print("Wave Complete",2f));
        if(tally.waves.Length==tally.wave+1){
            //Debug.Log("all waves completed");
            StartCoroutine(endGame());
        }else{
            boss = false;
            //Debug.Log("wave "+(tally.wave+1)+" completed");
            player.transform.GetChild(0).GetComponent<TokenManager>().reward();
        }
    }

    IEnumerator endGame(){
        yield return new WaitForSeconds(3.5f);
        win = true;
        player.GetComponent<HealthScript>().healthPoints = -10;
    }
}
