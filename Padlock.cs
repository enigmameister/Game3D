using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                        
public class Padlock : MonoBehaviour
{
    public Animator KeyRotate;      

    public PlayerManager pm;       
    public GameSounds GS;       

    public TMP_Text text;     
    public bool status = false;       

    public bool alreadyUsed = false;  

    public void Update()
    {
        Display();             
    }
    public void Display()
    { 
        string open = "OPENNED";    
        string close = "CLOSED";

       if (status)
        {
            KeyRotate.SetBool("Open", true);  
            text.SetText(open);            
            text.color = new Color32(0, 255, 0, 255); 
            pm.keyForOpen = false;                  
        }
       if(!status)
        {
            text.SetText(close);
            text.color= new Color32(255, 0, 0, 255);
            KeyRotate.SetBool("Open", false); 
        }
    }
    void OnTriggerEnter(Collider col) 
    {
    
        if (col.gameObject.CompareTag("Player") && pm.keyForOpen && !alreadyUsed) 
        {
                status = true;          
            alreadyUsed = true;     
                GS.padlock_granted();    
        }

       
        if (col.gameObject.CompareTag("Player") && pm.keyForOpen && alreadyUsed || col.gameObject.CompareTag("Player") && !pm.keyForOpen && alreadyUsed)
        {
            alreadyUsed = true;
        }
      
        if(col.gameObject.CompareTag("Player") && !pm.keyForOpen && !alreadyUsed)
        {
            status = false; 
            GS.padlock_deined(); 
        }
    }
}
