using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject PreviousConteiner;
    public GameObject CurrentConteiner;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        { 
            CurrentConteiner.SetActive(false);
            PreviousConteiner.SetActive(true);
        }
    }
}
