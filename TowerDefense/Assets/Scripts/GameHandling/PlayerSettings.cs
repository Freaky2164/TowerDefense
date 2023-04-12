using System;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    private static string gameFolder = "GameConfiguration";
    private string playerName;
    private DirectoryInfo playerSettingsFolder;

    public void initPlayerConfig()
    {
        string gameHandlingDir = Directory.GetCurrentDirectory();
        DirectoryInfo ScriptsDir = Directory.GetParent(gameHandlingDir);
        DirectoryInfo gameConfigurationDir = Directory.GetParent(ScriptsDir.ToString());
        gameConfigurationDir.MoveTo(gameFolder);

        foreach (DirectoryInfo playerConfigs in gameConfigurationDir.GetDirectories())
        {
            if (!playerConfigs.Name.Equals(playerName)) continue;
            playerSettingsFolder = playerConfigs;
        }

        if(playerSettingsFolder is null)
        {
            playerSettingsFolder = gameConfigurationDir.CreateSubdirectory(playerName);
        }
    }

    public DirectoryInfo getplayerSettingsFolder()
    {
        return playerSettingsFolder;
    }

    public string getPlayerName()
    {
        return playerName;
    }
    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }
}