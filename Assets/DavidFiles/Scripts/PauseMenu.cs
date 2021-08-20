using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject HUD;
    public GameObject crosshairs;
    public GameObject pauseMenu;
    public GameObject cursor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    
    public void ResumeGame()
    {
        if (!cursor.GetComponent<HealthScript>().isDead)
        {
            isGamePaused = false;
            pauseMenu.SetActive(false);
            cursor.GetComponent<MouseLockCursor>().Unpause();
            HUD.SetActive(true);
            crosshairs.SetActive(true);
            Time.timeScale = 1f;
        }
    }
    
    public void PauseGame()
    {
        if (!cursor.GetComponent<HealthScript>().isDead)
        {
            pauseMenu.SetActive(true);
            cursor.GetComponent<MouseLockCursor>().pause();
            HUD.SetActive(false);
            crosshairs.SetActive(false);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }

    public void MMenu()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
