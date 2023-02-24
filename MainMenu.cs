using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;   

public class MainMenu : MonoBehaviour
{
    [Header("Levels To Load")]
    public string _nameGameLevel;
   public void NewGameDialogYes() => SceneManager.LoadScene(_nameGameLevel);
    public void ExitButton() => Application.Quit();
}

