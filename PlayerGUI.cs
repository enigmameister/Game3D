using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;        
public class PlayerGUI : MonoBehaviour
{
    public Animator anim; 
    public GameManager GM; 
    public PlayerManager pm;    
    public WeaponSwitch ws;     
        
    public TMP_Text coinsCount;   
    public TMP_Text currentweapon;  
    public TMP_Text hp;             
    public TMP_Text keyCount;       

    
    public TMP_Text mission_coins;
    public TMP_Text mission_keys;
    

    public int objectives;      
    public GameObject missions; 

    public void TurnOn()
    {
        anim.SetBool("TurnObj", true);
    }     

    public void TurnOff()
    {
        anim.SetBool("TurnObj", false);
    }  

    public void Update()
    {
        coinsCount.SetText(pm.coins.ToString()); 
        keyCount.SetText(pm.keys.ToString()); 

        currentweapon.SetText(ws.weaponName.ToString()); 
        hp.SetText(pm.playerHP.ToString()); 

        PlayerHP();                       
        Missions();                   
     
    }
    public void Missions()
    {
        objectives = missions.transform.childCount;

        if (pm.coins >= 10)  
        {
            mission_coins.color = new Color32(0, 255, 0, 255);
            objectives--;
        }

        if (pm.keys >= 3)
        {
            mission_keys.color = new Color32(0, 255, 0, 255);
            objectives--;
        }
    }
    public void PlayerHP()
    {
        pm.playerHP = Mathf.Clamp(pm.playerHP, 0, 100);  
                                                         
    
        if (pm.playerHP >= 51)
                               
            hp.color = new Color32(37, 253, 76, 255);

        if (pm.playerHP <= 50)
            hp.color = new Color32(255, 255, 16, 255);

        if (pm.playerHP <= 25)
        {
            hp.color = new Color32(255, 16, 0, 255);
        }

        if (pm.playerHP <= 0)
        {
            hp.color = new Color32(0, 0, 0, 255);
            GM.YouLose = true;
            
        }
    }
}