using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using GameHandling;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SoundToggle : MonoBehaviour
    {
        public Image image;
        public Sprite startIamge;
        public Sprite pauseImage;
        private bool isActive =  true;

        public void soundToggle()
        {
            if (isActive) MuteSound();
            else ActivateSound();
        }

        private void MuteSound()
        {
            image.sprite = pauseImage;
            isActive = false;
            JsonFileHandler.PlayerSettings.setMuteSound(true);
            JsonFileHandler.PlayerSettings.SaveToJson();
        }
        
        private void ActivateSound()
        {
            image.sprite = startIamge;
            isActive = true;
            JsonFileHandler.PlayerSettings.setMuteSound(false);
            JsonFileHandler.PlayerSettings.SaveToJson();
        }
    }
}