using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDoors2 : MonoBehaviour
{
    private Animator Anim;       // Entry doors animation
    private AudioSource sound;        // audio doors component 

    public bool alreadyPlay = false;  // does sound was already played after triggered it

    void Start()
    {
        sound = GetComponent<AudioSource>(); // Doors open sound
        Anim = GetComponent<Animator>(); // Entry Doors Animation 
    }

  
    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlay)
        {
            if (other.CompareTag("Player"))
            {
                alreadyPlay = true;
                sound.Play();
                Anim.SetBool("EntryTrigger", true);
            }
        }

    }
}
