using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancesFactory : MonoBehaviour
{
    void Awake ()
    {
        SceneController.instance();
        SoundController.instance();
	}
}
