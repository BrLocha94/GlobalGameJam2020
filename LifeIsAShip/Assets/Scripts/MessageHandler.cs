﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageHandler : MonoBehaviour
{
    [Header("Hammer prefab and position to instantiate")]
    public Hammer hammer;
    public Transform position;

    [Header("Box to activate on hammer finish")]
    public GameObject optionBox;

    public void OnHandAnimationExit()
    {
        GameObject newHammer = Instantiate(hammer.gameObject, position);
        newHammer.transform.SetParent(gameObject.transform);

        StartCoroutine(MenuRoutine());
    }

    IEnumerator MenuRoutine()
    {
        yield return new WaitForSeconds(2f);

        iTween.ScaleTo(optionBox, iTween.Hash(
            "scale", new Vector3(1f, 1f, 0f),
            "time", 0.5f,
            "easetype", iTween.EaseType.easeOutElastic));
    }
}
