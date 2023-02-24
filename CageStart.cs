using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageStart : MonoBehaviour
{
    public Animator anim;

    public Padlock padlock;

    void Update()
    {
       if(padlock.status)
        {
            anim.SetBool("Trigger", true);
        }
    }
}
