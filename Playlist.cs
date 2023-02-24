using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                           
public class Playlist : MonoBehaviour
{
    public AudioClip[] clips;               
    public AudioSource source;              
    public float newClip;                   
    public float timer;                    
    public Animation anim;                  
    public TextMeshProUGUI textDisplay;     

    void Start()                                       
    {
        source = gameObject.AddComponent<AudioSource>();           
        source.volume = 0.1f;                                   

        anim = GetComponent<Animation>();                  
    }
    void Update()                                               
    {
        timer += Time.deltaTime;          
        {
            newCLIP();                          
            timer = 0;
        }
        if (Input.GetKeyDown(",")) 
        {
            source.Stop(); 
            anim.Stop();
            timer = newClip; 
        }
    }
    void newCLIP()
    {
        int clipNum = Random.Range(0,clips.Length);     
        if (!source.isPlaying)                
        {
            source.loop = true;                           
            source.PlayOneShot(clips[clipNum]);         
            textDisplay = GetComponentInChildren<TextMeshProUGUI>();   
            textDisplay.SetText("Song playing: " + clips[clipNum].name);
            
            anim.Play(); 
        }
        newClip = clips[clipNum].length;      
    }
}