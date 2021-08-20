using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathMenu : MonoBehaviour
{
    public bool deathHUDIsNotActive = false;
    public GameObject deathHUD;
    public GameObject HUD;
    public GameObject crosshairs;
    public GameObject player;
    public GameObject pauseMenu;
    public int tokenTally;
    public GameObject tokenDisplay;
    public int waveTally;
    public GameObject waveDisplay;
    public GameObject tokenCountSource;
    public GameObject gameManager;
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
            Time.timeScale = 0;
            deathHUDIsNotActive = true;
            crosshairs.SetActive(false);
            HUD.SetActive(false);
            deathHUD.SetActive(true);
            //player.GetComponent<MouseLockCursor>().pause();
            player.GetComponent<HealthScript>().isDead = true;
            pauseMenu.GetComponentInParent<PauseMenu>().PauseGame();

            pauseMenu.SetActive(false);
            pauseMenu.GetComponentInParent<PauseMenu>().unpause();
            Time.timeScale = 0f;
            //pauseMenu.GetComponentInParent<PauseMenu>().MMenu();//PauseGame();
        }
        tokenTally = tokenCountSource.GetComponent<TokenManager>().tokens;
        waveTally = gameManager.GetComponent<WaveTally>().wave;
        tokenDisplay.GetComponent<Text>().text = "Final Score: " + tokenTally;
        waveDisplay.GetComponent<Text>().text = "Wave: " + waveTally + 1;
    }

    public void MMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(0);
    }
}
