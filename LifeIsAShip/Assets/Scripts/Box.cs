using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    bool setted = false;

    void Awake()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
            "scale", new Vector3(1f, 1f, 1f),
            "time", 0.5f,
            "easetype", iTween.EaseType.easeInOutElastic,
            "oncomplete", "SettedBox",
            "oncompletetarget", gameObject
            ));
    }

    private void SettedBox()
    {
        setted = true;
    }
}
