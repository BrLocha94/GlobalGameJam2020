using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    public static SceneController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<SceneController>();

        if(_instance == null)
        {
            GameObject resourceObject = Resources.Load("SceneController") as GameObject;
            if(resourceObject != null)
            {
                GameObject instantiatedObject = Instantiate(resourceObject);
                _instance = instantiatedObject.GetComponent<SceneController>();
                DontDestroyOnLoad(instantiatedObject);
            }
        }

        return _instance;
    }
}
