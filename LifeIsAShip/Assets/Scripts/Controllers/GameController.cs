using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject tollboxUI;
    public Text toolboxText;
    public Text timeUI;

    float stageTime = 60f;
    float toolboxTime = 0f;

    bool countToolboxTime = false;
    bool gameClear = false;
    bool gameOver = false;

    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start ()
    {
        MapManager.instance.SortScenarios();
	}

    void Update()
    {
        if (gameClear == false && gameOver == false)
        {
            if (countToolboxTime == true)
            {
                string toolTimeConverted = "";
                if (toolboxTime < 1)
                    toolTimeConverted = "0";
                toolTimeConverted += toolboxTime.ToString("#.00");

                toolboxText.text = toolTimeConverted;

                toolboxTime -= Time.deltaTime;
                if (toolboxTime <= 0)
                    ReleaseToolbox();
            }

            stageTime -= Time.deltaTime;

            string stageTimeConverted = "";
            if (stageTime < 1)
                stageTimeConverted = "0";
            stageTimeConverted += stageTime.ToString("#.00");

            timeUI.text = "Time " + stageTimeConverted;

            if (stageTime <= 0)
            {
                GameClearRoutine();
            }
        }
    }

    public void GameClearRoutine()
    {
        gameClear = true;
        stageTime = 0f;
        SceneController.instance().LoadCutscene(0);
    }

    public void GetToolbox()
    {
        tollboxUI.SetActive(true);
        toolboxTime = 10f;
        countToolboxTime = true;
    }

    public void ReleaseToolbox()
    {
        tollboxUI.SetActive(false);
        toolboxTime = 0f;
        countToolboxTime = false;
    }
}
