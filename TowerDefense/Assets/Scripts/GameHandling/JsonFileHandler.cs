using System.IO;
using UnityEngine;

namespace GameHandling
{
    public class JsonFileHandler
    {
        public static DirectoryInfo GameConfigurationFolder;
        public static Settings PlayerSettings;
        public static SkillTree SkillTree;

        public static void Start()
        {
            GameConfigurationFolder = GetSettingFolder();
            loadSettings();
            loadSkillTree();
        }

        private static DirectoryInfo GetSettingFolder()
        {
            var gameHandlingDir = Directory.GetCurrentDirectory();
            var rootDirectory = new DirectoryInfo(gameHandlingDir);
            var gameFolder = Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "GameConfiguration";

            return new DirectoryInfo(rootDirectory.ToString() + gameFolder);
        }

        private static void loadSettings()
        {
            var settingFilePath = GameConfigurationFolder.ToString() + Path.DirectorySeparatorChar + Settings.FileName;
            if (!File.Exists(settingFilePath))
            {
                PlayerSettings = new Settings();
                PlayerSettings.SaveToJson();
            }
            else PlayerSettings = Settings.readFromJson();
        }

        private static void loadSkillTree()
        {
            var skillTreeFilePath = GameConfigurationFolder.ToString() + Path.DirectorySeparatorChar + SkillTree.FileName;
            if (!File.Exists(skillTreeFilePath))
            {
                SkillTree = new SkillTree();
                SkillTree.SaveToJson();
            }
            else SkillTree = SkillTree.readFromJson();
        }
    }
}

