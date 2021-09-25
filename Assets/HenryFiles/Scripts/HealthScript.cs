using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    public enum deathAction { loadLevelWhenDead, doNothingWhenDead };

    public float healthPoints = 30;
    public float respawnHealthPoints = 30;      //base health points
    public float regenDelay;
    float tBuffer;

    public int numberOfLives = 1;                   //lives and variables for respawning
    public bool isAlive = true;
    public bool coreDeath;
    public bool isDead = false;
    public string killedBy;

    public GameObject explosionPrefab;

    public deathAction onLivesGone = deathAction.doNothingWhenDead;

    public string LevelToLoad = "";

    private Vector3 respawnPosition;
    private Quaternion respawnRotation;

    Slider healthSlider;
    WaveTally tally;

    private AudioSoruce m_AudioSource; 
    [SerializeField] private AudioClip m_DeathSound;

    // Use this for initialization
    void Start()
    {
        tally = GameObject.Find("manager").GetComponent<WaveTally>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        // store initial position as respawn location
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;
        tBuffer = regenDelay;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = healthPoints;
        if(Time.time>=tBuffer&&healthPoints<respawnHealthPoints){
            healthPoints++;
            tBuffer = Time.time + regenDelay - tally.wave;
        }
        if (healthPoints <= 0)
        {               // if the object is 'dead'
            numberOfLives--;                    // decrement # of lives, update lives GUI

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (numberOfLives > 0)
            { // respawn
                transform.position = respawnPosition;   // reset the player to respawn position
                transform.rotation = respawnRotation;
                healthPoints = respawnHealthPoints; // give the player full health again
            }
            else
            { // here is where you do stuff once ALL lives are gone)
                isDead = true;
                healthPoints = 0;
                isAlive = false;
                switch (onLivesGone)
                {
                    case deathAction.loadLevelWhenDead:
                        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                    case deathAction.doNothingWhenDead:
                        // do nothing, death must be handled in another way elsewhere
                        break;
                }
            }
        }
    }

    public bool ApplyDamage(float amount)
    {
        healthPoints -= amount;
        if(healthPoints<=0){
            
            return true;
        }else{
            return false;
        }
    }

    private void PlayDeathSound()
    {
        m_AudioSource.clip = m_DeathSound;
        m_AudioSource.Play();
    }

    public void ApplyHeal(float amount)
    {
        healthPoints = healthPoints + amount;
    }

    public void ApplyBonusLife(int amount)
    {
        //numberOfLives = numberOfLives + amount;
    }

    public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation)
    {
        respawnPosition = newRespawnPosition;
        respawnRotation = newRespawnRotation;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("bullet")){
            healthPoints -= 4;
            Destroy(other.gameObject);
            if(healthPoints<=0){
                killedBy = "by RK-49 \"Ranger\"";
            }
        }
    }
}
