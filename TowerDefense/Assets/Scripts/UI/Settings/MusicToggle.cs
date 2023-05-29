using System.Collections;
using System.Collections.Generic;
using GameHandling;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Settings
{
    public class MusicToggle : MonoBehaviour
    {
        public Image image;
        public Sprite startIamge;
        public Sprite pauseImage;
        private bool isMusicMuted;
        
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDisable()
        { 
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            isMusicMuted = JsonFileHandler.PlayerSettings.muteMusic;
            if (scene.name != "SettingsScene") return;

            image.sprite = (isMusicMuted) ? startIamge : pauseImage;
        }
        
        public void musicToggle()
        {
            bool shouldMute = !isMusicMuted;
            if (shouldMute) MuteMusic();
            else ActivateMusic();
        }

        private void MuteMusic()
        {
            image.sprite = startIamge;
            isMusicMuted = true;
            JsonFileHandler.PlayerSettings.setMuteMusic(true);
            JsonFileHandler.PlayerSettings.SaveToJson();
            MusicScript.instance.Mute();
        }
        
        private void ActivateMusic()
        {
            image.sprite = pauseImage;
            isMusicMuted = false;
            JsonFileHandler.PlayerSettings.setMuteMusic(false);
            JsonFileHandler.PlayerSettings.SaveToJson();
            MusicScript.instance.Play();
        }
    }
}