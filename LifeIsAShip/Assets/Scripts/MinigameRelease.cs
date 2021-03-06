﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameRelease : Minigame
{
    bool isOver = false;
    bool checking = false;
    bool enteredRegion = false;

    void Update()
    {
        if (checking == false)
        {
            if (isOver == true && Input.GetMouseButtonDown(0))
            {
                checking = true;
            }
        }
        else
        {
            if(isOver == true && !Input.GetMouseButton(0))
            {
                //Released
                //Check if win or not
                // call OnFinishedGame(bool result) passing the check resutl
            }
            else if(isOver == false)
            {
                //Is not over the object
                checking = false;
            }
        }
    }

    private void OnMouseEnter()
    {
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }

    public void EnterRegion()
    {
        enteredRegion = true;
    }

    public void ExitRegion()
    {
        enteredRegion = false;
    }
}
