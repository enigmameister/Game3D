using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TittleAnim : MonoBehaviour
{

    private Animation anim;
    
     void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        anim["UI"].layer = 123;
    }
    void Update()
    {
  
        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.Stop();
            
            Debug.Log("Zadzia³a³o update");
        }
    }
}
