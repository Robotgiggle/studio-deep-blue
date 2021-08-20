using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathMenu : MonoBehaviour
{
    public bool deathHUDIsNotActive = false;
    public GameObject deathHUD;
    public GameObject HUD;
    public GameObject crosshairs;
    public GameObject player;
    public GameObject pauseMenu;
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
        }
    }

    public void MMenu()
    {
        SceneManager.LoadScene(0);
    }
}
