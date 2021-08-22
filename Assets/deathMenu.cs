using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathMenu : MonoBehaviour
{
    public bool deathHUDIsNotActive = false;
    public GameObject deathHUD;
    public GameObject playerHUD;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject tokenCountSource;
    public GameObject gameManager;
    public int kills = 0;
    int tokenTally;
    int waveTally;
    string CoD;
    //public bool isGoingToMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<HealthScript>().healthPoints <= 0)// && !isGoingToMenu)// && deathHUDIsNotActive)
        {
            if(GameObject.Find("manager").GetComponent<GameManager>().win){
                deathHUD.transform.GetChild(1).gameObject.SetActive(false);
                deathHUD.transform.GetChild(3).gameObject.SetActive(false);
                deathHUD.transform.GetChild(4).gameObject.SetActive(true);
            }
            Time.timeScale = 0;
            deathHUDIsNotActive = true;
            playerHUD.SetActive(false);
            deathHUD.SetActive(true);
            //player.GetComponent<MouseLockCursor>().pause();
            player.GetComponent<HealthScript>().isDead = true;
            pauseMenu.GetComponentInParent<PauseMenu>().PauseGame();

            pauseMenu.SetActive(false);
            pauseMenu.GetComponentInParent<PauseMenu>().unpause();
            Time.timeScale = 0f;
            //pauseMenu.GetComponentInParent<PauseMenu>().MMenu();//PauseGame();
        }
        if(player.GetComponent<HealthScript>().coreDeath){
            CoD = "Core Destroyed";
        }else{
            CoD = "You Were Killed";
        }
        tokenTally = tokenCountSource.GetComponent<TokenManager>().tokens;
        waveTally = gameManager.GetComponent<WaveTally>().wave;
        deathHUD.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = CoD;
        deathHUD.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Wave: " + (waveTally + 1).ToString();
        deathHUD.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Kills: " + kills.ToString();
        deathHUD.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Tokens: " + tokenTally.ToString();
        deathHUD.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = player.GetComponent<HealthScript>().killedBy;
    }

    public void MMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(0);
    }
}
