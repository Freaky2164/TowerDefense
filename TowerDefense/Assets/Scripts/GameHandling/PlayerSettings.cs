using System.IO;
using UnityEngine;

namespace GameHandling
{
    public class PlayerSettings
    {
        private static readonly string GameFolder = Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar + "GameConfiguration";
        private static readonly string PlayerName;

        static PlayerSettings()
        {
            PlayerName = JsonFileHandler.PlayerName;
        }

        public static void initPlayerConfig()
        {
            string gameHandlingDir = Directory.GetCurrentDirectory();
            DirectoryInfo rootDirectory = new DirectoryInfo(gameHandlingDir);
            DirectoryInfo gameConfigurations = new DirectoryInfo(rootDirectory.ToString() + GameFolder);

            foreach (DirectoryInfo playerConfigs in gameConfigurations.GetDirectories())
            {
                if (!playerConfigs.Name.Equals(PlayerName)) continue;
                JsonFileHandler.PlayerSettingsFolder = playerConfigs;
                GetExisitingSettings();
            }

            if (JsonFileHandler.PlayerSettingsFolder is null)
            {
                JsonFileHandler.PlayerSettingsFolder = gameConfigurations.CreateSubdirectory(PlayerName);
                CreateDefaultSettings();
            }
        }

        private static void CreateDefaultSettings()
        {
            Settings settings = new Settings();
            settings.SaveToJson();
            JsonFileHandler.Settings = settings;
            SkillTree tree = new SkillTree();
            tree.createDefaultValues();
            tree.SaveToJson();
            JsonFileHandler.SkillTree = tree;
        }

        private static void GetExisitingSettings()
        {
            JsonFileHandler.Settings = Settings.readFromJson();
            JsonFileHandler.SkillTree = SkillTree.readFromJson();
        }
    }
}