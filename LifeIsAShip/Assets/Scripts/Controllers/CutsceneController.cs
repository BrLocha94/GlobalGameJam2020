using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [Header("Scene animators")]
    public Animator rickGuyAnimator;
    public Animator poorGuyAnimator;


    bool used = false;

    void Update()
    {
        if (used == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                AdvanceAnimation();
        }    
    }

    public void AdvanceAnimation()
    {
        rickGuyAnimator.SetTrigger("go");
        used = true;
    }
}
