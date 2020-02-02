using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NodeBehaviour : MonoBehaviour
{
    private int id;

    private RoomState roomStateValue;

    [Header("Node Graph Directions")]
    public NodeBehaviour up;
    public NodeBehaviour down;
    public NodeBehaviour left;
    public NodeBehaviour right;

    private NodeConfig config;

    public NodeBehaviour(int newId)
    {
        roomStateValue = RoomState.New;
        id = newId;
    }

    public void SetConfig(NodeConfig newConfig)
    {
        this.config = newConfig;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = config.animatorController;
    }

    public bool CanInitiateMinigame()
    {
        if (config != null)
        {
            if (config.miniGame != null)
                return true;
        }

        return false;
    }

    public void StartMiniGame(Transform spawPosition)
    {
        print("AQUI");
        GameObject newMiniGame = Instantiate(config.miniGame.gameObject);
        newMiniGame.GetComponent<Minigame>().OnInitiatedGame(spawPosition);
    }

    void Awake()
    {
        //Sprite imageBackgorund = Resources.Load<Sprite>("Room/room_template");
        //gameObject.GetComponent<SpriteRenderer>().sprite = imageBackgorund;
    }

    void initialBehaviour(string roomType)
    {


    }

    public bool CheckCanMove(PassageDirection direction)
    {
        if (direction == PassageDirection.Up && up != null)
            return true;
        else if (direction == PassageDirection.Donw && down != null)
            return true;
        else if (direction == PassageDirection.Left && left != null)
            return true;
        else if (direction == PassageDirection.Right && right != null)
            return true;

        return false;
    }

    public NodeBehaviour GetNextNode(PassageDirection direction)
    {
        if (direction == PassageDirection.Up)
            return up;
        else if (direction == PassageDirection.Donw)
            return down;
        else if (direction == PassageDirection.Left)
            return left;
        else if (direction == PassageDirection.Right)
            return right;

        return null;
    }

    public void IncreaseBackgroundValue()
    {
        RoomState currentBackgroundValue = GetBackgroudValue();

        if ((int)currentBackgroundValue < Enum.GetNames(typeof(RoomState)).Length - 1)
        {
            roomStateValue++;
        }
    }

    public void DecreaseBackgroundValue()
    {
        RoomState currentBackgroundValue = GetBackgroudValue();

        if ((int)currentBackgroundValue == Enum.GetNames(typeof(RoomState)).Length - 1)
        {
            Debug.Log("Max ");
        }

        else  if ((int)currentBackgroundValue > 0)
        {
            roomStateValue--;
        }
    }

    public RoomState GetBackgroudValue()
    {
        return roomStateValue;
    }
}
