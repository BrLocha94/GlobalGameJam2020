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

    bool emergency = false;
    float timer = 0f;

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
            if (config.miniGame != null && roomStateValue == RoomState.Medium)
                return true;
        }

        return false;
    }

    public void StartMiniGame(Transform spawPosition)
    {
        GameObject newMiniGame = Instantiate(config.miniGame.gameObject);
        newMiniGame.GetComponent<Minigame>().OnInitiatedGame(spawPosition);
    }

    public void DecriptNode()
    {
        if (roomStateValue != RoomState.Broken)
            gameObject.GetComponent<Animator>().SetTrigger("lost");
    }

    void Update()
    {
        if (config != null)
        {
            if (config.miniGame != null && emergency == false)
            {
                timer += Time.deltaTime;
                if (timer > 10)
                    SortEmergency();
            }
        }
    }

    public void SortEmergency()
    {
        int random = UnityEngine.Random.Range(0, 20);
        if (random == 0)
        {
            emergency = true;
            roomStateValue = RoomState.Medium;
            gameObject.GetComponent<Animator>().Play("state-01");
        }
    }

    public void FixedNode()
    {
        timer = 0f;
        roomStateValue = RoomState.New;
        gameObject.GetComponent<Animator>().Play("state-00");
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

        else if ((int)currentBackgroundValue > 0)
        {
            roomStateValue--;
        }
    }

    public RoomState GetBackgroudValue()
    {
        return roomStateValue;
    }


    public void SetReferencenull(string SideDoor)
    {
        SideDoor = SideDoor.ToLower();

        if (string.Equals(SideDoor, "up"))
        {
            up = null;
        }
        else if (string.Equals(SideDoor, "down"))
        {
            down = null;
        }
        else if (string.Equals(SideDoor, "left"))
        {
            left = null;
        }
        else if (string.Equals(SideDoor, "right"))
        {
            right = null;
        }

    }

}
