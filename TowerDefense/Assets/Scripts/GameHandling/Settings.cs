using System.IO;
using UnityEngine;

namespace GameHandling
{
    [System.Serializable]
    public class Settings
    {
        [System.NonSerialized]
        public static string FileName = "Settings.json";

        public bool muteMusic;
        public bool muteSounds;


        public Settings()
        {
            muteMusic = false;
            muteSounds = false;
        }
        

        public void SaveToJson()
        {
            Settings settings = this;
            if (!(JsonFileHandler.GameConfigurationFolder is null))
            {
                var json =  JsonUtility.ToJson(settings);
                File.WriteAllText(JsonFileHandler.GameConfigurationFolder.FullName + Path.DirectorySeparatorChar + FileName, json);
            }
        }
        
        public static Settings readFromJson()
        {
            if (!(JsonFileHandler.GameConfigurationFolder is null))
            {
                string json = File.ReadAllText(JsonFileHandler.GameConfigurationFolder.FullName + Path.DirectorySeparatorChar +  FileName);
                return JsonUtility.FromJson<Settings>(json);
            }
            return null;
        }


        public bool getMuteMusic()
        {
            return muteMusic;
        }
        public bool getMuteSound()
        {
            return muteSounds;
        }
        
        public void setMuteMusic(bool toggle)
        {
            muteMusic = toggle;
        }
        public void setMuteSound(bool toggle)
        {
            muteSounds = toggle;
        }

    }
}