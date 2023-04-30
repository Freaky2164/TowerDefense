using System.IO;
using UnityEngine;

namespace GameHandling
{
    [System.Serializable]
    public class Settings
    {
        [System.NonSerialized]
        private static string _fileName = "Settings.json";

        public bool muteMusic;
        public bool muteSounds;


        public void SaveToJson()
        {
            if (!(JsonFileHandler.PlayerSettingsFolder is null))
            {
                var json = JsonUtility.ToJson(this);
                File.WriteAllText(JsonFileHandler.PlayerSettingsFolder.FullName + Path.DirectorySeparatorChar + _fileName, json);
            }
        }
        
        public static Settings readFromJson()
        {
            if (!(JsonFileHandler.PlayerSettingsFolder is null))
            {
                string json = File.ReadAllText(JsonFileHandler.PlayerSettingsFolder.FullName + Path.DirectorySeparatorChar +  _fileName);
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
    }
}