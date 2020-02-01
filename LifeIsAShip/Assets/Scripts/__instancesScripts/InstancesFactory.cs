using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancesFactory : MonoBehaviour
{
    public GameObject Node;
    void Awake ()
    {
        Instantiate(Node);
        SceneController.instance();
	}
}
