using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DiegoBravo;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool cannotPause;
    public static bool isPausedByQTE;
    public static bool pausedEverything;

    bool test;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        pausedEverything = false;
        isPausedByQTE = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseInput();
        }
    }
    public void PauseInput()
    {
        if (isPausedByQTE && !pausedEverything)
        {
            PauseGame();
        }
        else if (isPausedByQTE && pausedEverything)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        FindObjectOfType<SetPlayback>().Stop();
        FindObjectOfType<QTESystem>().isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPausedByQTE = true;
        pausedEverything = true;
    }
    public void PauseByQTE()
    {
        FindObjectOfType<SetPlayback>().Stop();
        FindObjectOfType<QTESystem>().isPaused = false;
        Time.timeScale = 0f;
        isPausedByQTE = true;
    }
    public void ResumeGame()
    {
        if (!test)
        {
            FindObjectOfType<SetPlayback>().Resume();
            FindObjectOfType<QTESystem>().isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPausedByQTE = false;
            pausedEverything = false;
        }
        else
        {
            FindObjectOfType<SetPlayback>().Stop();
            FindObjectOfType<QTESystem>().isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 0f;
            isPausedByQTE = true;
            pausedEverything = false;
        }
    }
}
