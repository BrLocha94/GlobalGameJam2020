using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSideController : MonoBehaviour
{

    private List<string> sideOpenList;

    void Awake()
    {
        TextAsset sideOpenFile = Resources.Load<TextAsset>("OpenSides");
        string sideOpenString = sideOpenFile.text;
        sideOpenList = sideOpensLoader(sideOpenString);

    }

    private List<string> sideOpensLoader(string sideOpenStringParam)
    {
        List<string> sideLevelsList = new List<string>();
        string tempString = string.Empty;
        for (int i = 0; i < sideOpenStringParam.Length; i++)
        {
            if (!string.Equals(sideOpenStringParam[i].ToString(), "@"))
            {

                tempString += sideOpenStringParam[i];

            }
            else
            {
                sideLevelsList.Add(tempString);
                tempString = string.Empty;
            }
        }

        return sideLevelsList;
    }

    private List<int> OpenedValues(string levelSelectedOpenValuesList)
    {
        List<int> openCheckValuesList = new List<int>();
        for (int i = 0; i < levelSelectedOpenValuesList.Length; i++)
        {

            if (!string.Equals(levelSelectedOpenValuesList[i].ToString(), "#"))
            {


                openCheckValuesList.Add(int.Parse(levelSelectedOpenValuesList[i].ToString()));
            }
        }
        return openCheckValuesList;
    }

    public List<int> GetListOfSideOpen(int levelNumber)
    {
        return OpenedValues(sideOpenList[levelNumber]); ;
    }

    public int GetQtdOfLevels()
    {
        return sideOpenList.Count;
    }
}
