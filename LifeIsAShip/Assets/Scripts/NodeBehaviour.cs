using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour
{


    enum passageDirection
    {
        Up,
        Donw,
        Left,
        Right

    }

    enum roomState
    {
        New,
        Medium,
        Rusty,
        Broken
    }
    void Awake()
    {

        /*int val = Enum.GetNames(typeof(passageDirection)).Length;*/
        
    }

    
}
