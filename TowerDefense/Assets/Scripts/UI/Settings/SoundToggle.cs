using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using GameHandling;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SoundToggle : MonoBehaviour
    {
        public Image image;
        public Sprite startIamge;
        public Sprite pauseImage;
        private bool isSoundMuted;
        
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
            isSoundMuted = JsonFileHandler.PlayerSettings.muteSounds;
            if (scene.name != "SettingsScene") return;
            image.sprite = (isSoundMuted) ? startIamge : pauseImage;
        }
        
        public void soundToggle()
        {
            bool shouldMute = !isSoundMuted;
            if (shouldMute) MuteSound();
            else ActivateSound();
        }

        private void MuteSound()
        {
            image.sprite = startIamge;
            isSoundMuted = true;
            JsonFileHandler.PlayerSettings.setMuteSound(true);
            JsonFileHandler.PlayerSettings.SaveToJson();
        }
        
        private void ActivateSound()
        {
            image.sprite = pauseImage;
            isSoundMuted = false;
            JsonFileHandler.PlayerSettings.setMuteSound(false);
            JsonFileHandler.PlayerSettings.SaveToJson();
        }
    }
}