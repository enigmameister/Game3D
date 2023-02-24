using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour
{
    public GameSounds GS;  
    private Animator Anim; 

    bool played;
    void Start() => Anim = GetComponent<Animator>();

    public void OnTriggerEnter(Collider col)
    {
        if (!played)  
        {
            if (col.gameObject.CompareTag("Player"))
                GS.DoorsSound();
            Anim.SetBool("EntryTrigger", true);
            played = true;
        }
    }
}
