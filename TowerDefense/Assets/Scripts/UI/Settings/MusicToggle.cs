using System.Collections;
using System.Collections.Generic;
using GameHandling;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class MusicToggle : MonoBehaviour
    {
        public Image image;
        public Sprite startIamge;
        public Sprite pauseImage;
        public MusicScript music;
        private bool isActive =  true;
        
        public void musicToggle()
        {
            if (isActive) MuteMusic();
            else ActivateMusic();
        }

        private void MuteMusic()
        {
            image.sprite = pauseImage;
            isActive = false;
            JsonFileHandler.PlayerSettings.setMuteMusic(true);
            music.Mute();
        }
        
        private void ActivateMusic()
        {
            image.sprite = startIamge;
            isActive = true;
            JsonFileHandler.PlayerSettings.setMuteMusic(false);
        }
    }
}