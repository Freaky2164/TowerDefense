using System.IO;
using UnityEngine;

namespace GameHandling
{
    public class JsonFileHandler
    {
        public static string PlayerName;
        private static PlayerSettings _playerSettings;
        public static DirectoryInfo PlayerSettingsFolder;
        public static Settings Settings;
        public static SkillTree SkillTree;

        public JsonFileHandler(string playername)
        {
            PlayerName = playername;
        }
        
        public static void Start()
        {
            PlayerSettings.initPlayerConfig();
        }
    }
}

