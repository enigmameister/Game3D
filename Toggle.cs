using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
   public void FullScene(bool is_fullscene)
    {
        Screen.fullScreen = is_fullscene;
    }
}
