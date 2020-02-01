using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    bool move = false;
    int scale = 1;

    float time = 0.5f;

    public Color firstPlace;
    public Color secondPlace;
    public Color lastPlace;

    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash(
            "scale", new Vector3(1f, 1f, 1f),
            "time", 1f,
            "easetype", iTween.EaseType.easeInOutElastic,
            "oncomplete", "InitiateMovement",
            "oncompletetarget", gameObject
            ));
    }

    private void Update()
    {
        if (move)
        {
            MoveHammer();

            time += Time.deltaTime;

            if(time >= 1f)
            {
                scale = -scale;
                time = 0f;
            }
        }
    }

    private void MoveHammer()
    {
        gameObject.transform.Translate(0f, scale * 1f * Time.deltaTime, 0f);
    }

    private void InitiateMovement()
    {
        move = true;
    }
}
