using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSideController : MonoBehaviour {

	private List<int> openValuesFinalList;
	private List<string> sideOpenList;

	void Start ()
	{
		TextAsset sideOpenFile = Resources.Load<TextAsset>("OpenSides");
		string sideOpenString = sideOpenFile.text;
		sideOpenList = sideOpensLoader(sideOpenString);
		openValuesFinalList = OpenedValues(sideOpenList[1]);
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

	public List<int> GetListOfSideOpen()
	{
		return openValuesFinalList;
	}

	public int GetQtdOfLevels()
	{
		return sideOpenList.Count;
	}
}
