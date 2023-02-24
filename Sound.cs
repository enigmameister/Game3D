using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameSounds GS;
    public bool alreadyPlay = false;

    void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlay)
        {
            if (other.CompareTag("Player"))
            {
                GS.ScoreSound();
                alreadyPlay = true;
            }
        }

    }
}
