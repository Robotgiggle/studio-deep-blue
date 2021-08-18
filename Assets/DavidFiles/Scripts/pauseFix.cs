using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseFix : MonoBehaviour
{
    public GameObject cursor;

    void Start()
    {
        PauseGame();
        ResumeGame();
    }

    public void ResumeGame()
    {
        cursor.GetComponent<MouseLockCursor>().Unpause();
        Time.timeScale = 1f;
    }

    void PauseGame()
    {
        cursor.GetComponent<MouseLockCursor>().pause();
        Time.timeScale = 0f;
    }
}
