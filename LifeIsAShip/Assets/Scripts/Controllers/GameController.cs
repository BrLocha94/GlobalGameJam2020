﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	void Start ()
    {
        MapManager.instance.SortScenarios();
	}
}
