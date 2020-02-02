using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public MinigameType minigameType;

    public void OnInitiatedGame(Transform spawPosition)
    {
        //Set position
        gameObject.transform.position = spawPosition.position;
    }

    public void OnFinishedGame(bool result)
    {
        if(result == true)
        {
            //Add score
            MapManager.instance.FixedNode();
        }
        else
        {
            //Depriciate Node
            MapManager.instance.DecriptNode();
        }

        //Liberate player to new actions
        Player.instance.FinishedMinigame();
        Destroy(gameObject);
    }
}
