using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRules : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject GUI;

    public bool GameOver = false;
    public bool GameWin = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
    }

    public void EndGame()
    {

    }

    // Buttons functions
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame() // Close R1SEN
    {
        Application.Quit();
    }
}
