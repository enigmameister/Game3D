using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;    
    void Start()
    {
        if(!PlayerPrefs.HasKey("SoundVolume"))              
        {
            PlayerPrefs.SetFloat("SoundVolume", 1);  
            Load();
        }
        else
            Load();
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;      
        Save();                                        
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("SoundVolume");  
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("SoundVolume", volumeSlider.value);
    }
}