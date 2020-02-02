using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [Header("Scene animators")]
    public Animator rickGuyAnimator;
    public Animator poorGuyAnimator;

    [Header("UI Objects")]
    public GameObject dialogBox;

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
        iTween.ScaleTo(dialogBox, iTween.Hash(
            "scale", new Vector3(0f, 0f, 0f),
            "time", 0.2f,
            "easetype", iTween.EaseType.easeOutElastic));

        rickGuyAnimator.SetTrigger("go");
        used = true;
    }
}
