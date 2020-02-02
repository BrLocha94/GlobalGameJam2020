using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    #region Instance

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

    #endregion

    public void LoadOpen(float time)
    {
        SceneManager.LoadScene("Open", LoadSceneMode.Single);
        //StartCoroutine(LoadScene("Open", time));
    }

    public void LoadGame(float time)
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        //StartCoroutine(LoadScene("Game", time));
    }

    public void LoadCutscene(float time)
    {
        SceneManager.LoadScene("Cutscene", LoadSceneMode.Single);
        //StartCoroutine(LoadScene("Cutscene", time));
    }

    IEnumerator LoadScene(string name, float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
