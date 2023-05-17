using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Audio;
using GameHandling;
using Unity.VisualScripting;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler I;
    private AudioSource _audioSource;
    private Dictionary<Sound, AudioClip> _sounds;
    private Settings _settings;

    private void Start()
    {
        _settings = JsonFileHandler.PlayerSettings;
        _audioSource = this.AddComponent<AudioSource>();
        LoadSounds();
    }

    private void Awake()
    {
        if (I != null && I != this)
        {
            Destroy(gameObject);
            return;
        }
        I = this;
        DontDestroyOnLoad(this);
    }

    public void Play(Sound sound)
    {
        if(_settings.muteSounds) return;
        _sounds.TryGetValue(sound, out var s);
        _audioSource.PlayOneShot(s);
    }

    private void LoadSounds()
    {
        _sounds = new Dictionary<Sound, AudioClip>
        {
            {Sound.ButtonClick, Resources.Load("audio/Free UI Click Sound Effects Pack/AUDIO/Button/ButtonClick") as AudioClip},
            
            {Sound.EnemyDestroyed, Resources.Load("audio/Free UI Click Sound Effects Pack/AUDIO/Pop/BaseEnemyDestroyed") as AudioClip},
            
            {Sound.CanonTowerShot, Resources.Load("audio/guns/GunShot") as AudioClip},
            {Sound.BombTowerShot, Resources.Load("audio/guns/GunShot") as AudioClip},
        };
    }
}
