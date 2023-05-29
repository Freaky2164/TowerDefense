using System.Collections;
using System.Collections.Generic;
using GameHandling;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public static MusicScript instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        JsonFileHandler.Start();
        if (JsonFileHandler.PlayerSettings.getMuteMusic()) Mute();
        else Play();
    }

    public void Mute()
    { 
        GetComponent<AudioSource>().Stop();
    }

    public void Play()
    {
        GetComponent<AudioSource>().Play();
    }
}
