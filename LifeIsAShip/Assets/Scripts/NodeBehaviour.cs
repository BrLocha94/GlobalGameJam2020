using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeBehaviour : MonoBehaviour
{

    private int id;

    public enum passageDirection
    {
        Up,
        Donw,
        Left,
        Right

    }

    public enum roomState
    {
        New,
        Medium,
        Broken,
        Condemned
    }

    private roomState roomStateValue;


    public NodeBehaviour(int newId)
    {
        roomStateValue = roomState.New;
        id = newId;
    }


    void Awake()
    {

        Sprite imageBackgorund = Resources.Load<Sprite>("Room/room_template");
        gameObject.GetComponent<SpriteRenderer>().sprite = imageBackgorund;


    }

    void initialBehaviour(string roomType)
    {


    }


    public void IncreaseBackgroundValue()
    {
        roomState currentBackgroundValue = GetBackgroudValue();

        if ((int)currentBackgroundValue < Enum.GetNames(typeof(roomState)).Length - 1)
        {
            roomStateValue++;
        }

    }


    public void DecreaseBackgroundValue()
    {
        roomState currentBackgroundValue = GetBackgroudValue();


        if ((int)currentBackgroundValue == Enum.GetNames(typeof(roomState)).Length - 1)
        {
            Debug.Log("Max ");
        }

        else  if ((int)currentBackgroundValue > 0)
        {
            roomStateValue--;
        }

    }

    public roomState GetBackgroudValue()
    {
        return roomStateValue;
    }





}
