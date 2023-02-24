using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coins = 0;
    public int keys = 0;
    public int enemies = 0;

    public bool keyForOpen;

    public int playerHP = 100; 
    
    public PlayerMotor player;
    public Transform playerpos;
    public GameManager GM;
    public GameSounds GS;
    void OnTriggerExit(Collider col)
     {
            if (col.gameObject.CompareTag("Gravity"))
            {
                player.speed = 8f;
                 player.gravity = -25f;
            }

    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Acid"))
        {
            playerHP--;
        }

       
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Coins"))
        {
            GS.CoinSound();
            coins++;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Poisons"))
        {
            playerHP -= 10;
            
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Healths"))
        {
            if (playerHP < 99)
            {
                GS.HealthSound();
                playerHP += 20;
                
                Destroy(col.gameObject);
            }
        }

        if(col.gameObject.CompareTag("Keys"))  
        {
            GS.KeySound();
            keys++;
            keyForOpen = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Gravity"))
        {  
            player.speed = 60;
            player.gravity = -10f;
        }

        if (col.gameObject.CompareTag("Finish"))   
        {
            GM.YouWin = true;
        }

    }
 }

