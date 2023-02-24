using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoubleDoors : MonoBehaviour
{
    private Animator Anim;     
    public GameSounds GS;

    public bool alreadyPlay = false;
    public bool alreadyClose = false;
    void Start()
    {
        Anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlay)
        {
            if (other.CompareTag("Player"))
            {
                alreadyPlay = true;
                Anim.SetBool("Stay", true);
                GS.DoorsSound2();
                alreadyClose = false;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (!alreadyClose)
        {
            if (other.CompareTag("Player"))
            {
                alreadyClose = true;
                Anim.SetBool("Stay", false);
                GS.DoorsSound2();
                alreadyPlay = false;
            }
        }
    }
}
