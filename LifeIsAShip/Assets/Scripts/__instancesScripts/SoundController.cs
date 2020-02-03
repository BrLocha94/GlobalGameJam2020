using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundAudio;
    [SerializeField]
    private AudioSource sfxAudio;

    public AudioClip [] sfxAudioClips;

    #region Instance

    private static SoundController _instance;
    public static SoundController instance()
    {
        if (_instance != null)
            return _instance;

        _instance = GameObject.FindObjectOfType<SoundController>();

        if (_instance == null)
        {
            GameObject resourceObject = Resources.Load("SoundController") as GameObject;
            if (resourceObject != null)
            {
                GameObject instantiatedObject = Instantiate(resourceObject);
                _instance = instantiatedObject.GetComponent<SoundController>();
                DontDestroyOnLoad(instantiatedObject);
            }
        }

        return _instance;
    }

    #endregion

    public void PlayClipSfx(string name)
    {
        if (name.Equals("jump"))
            sfxAudio.clip = sfxAudioClips[0];
        else if (name.Equals("explosion"))
            sfxAudio.clip = sfxAudioClips[1];
        else if (name.Equals("toolbox"))
            sfxAudio.clip = sfxAudioClips[2];
        else if (name.Equals("minigame-enter"))
            sfxAudio.clip = sfxAudioClips[3];
        else if (name.Equals("mouse-click"))
            sfxAudio.clip = sfxAudioClips[4];

        sfxAudio.Play();
    }
}
