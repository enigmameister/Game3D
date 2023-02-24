using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using TMPro;                    
public class GameManager : MonoBehaviour
{
    
    public bool YouWin = false;             
    public bool YouLose = false;                

    public static bool GameIsPaused = false;
    
    public TMP_Text result_coins;   
    public TMP_Text result_keys;   

    public GameObject LoseContainer; 
    public GameObject WinContainer;
    public GameObject pauseMenuUI;  
    public GameObject GUI;   
    public GameObject WS;    

    public Stopwatch stopwatch;
    public PlayerManager PM; 
    public GameSounds GS;
    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()           
    {
        EndGame();             
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused) Resume();             
                else Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;

        pauseMenuUI.SetActive(false);  
        GUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        GUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void BackToMenu() => SceneManager.LoadScene("Menu");
    public void PlayAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void QuitGame() => Application.Quit(); 

    public void EndGame()
    {

        result_coins.SetText(PM.coins.ToString());   
       result_keys.SetText(PM.keys.ToString());   

        if (YouWin) 
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Cursor.visible = false;

            GS.BG_SoundStop();          
            stopwatch.StopTimer(); 
            Time.timeScale = 0f;   

            GUI.SetActive(false);
            WS.SetActive(false); 
            WinContainer.SetActive(true);    
        }
        if(YouLose)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            GS.BG_SoundStop();
            stopwatch.StopTimer();
            Time.timeScale = 0f;

            GUI.SetActive(false);
            WS.SetActive(false);
            LoseContainer.SetActive(true);
        }
    }
}
