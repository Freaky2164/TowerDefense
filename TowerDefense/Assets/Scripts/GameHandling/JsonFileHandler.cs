using System;
using System.IO;
using System.Linq;
using GameHandling;
using Unity.VisualScripting;
using UnityEngine;

public class JsonFileHandler : MonoBehaviour
{
    private string playerName;
    private PlayerSettings playerSettings;
    private WaveManagement waveManagement;
    
    private void Start()
    {
       initPlayer();
       initWaves();
    }

    private void initWaves()
    {
        waveManagement = new WaveManagement();
        waveManagement.setSettingsFolder(playerSettings.getplayerSettingsFolder());
        waveManagement = waveManagement.readFromJson();
    }

    private void initPlayer()
    {
        playerSettings = new PlayerSettings();
        playerSettings.setPlayerName(playerName);
        playerSettings.initPlayerConfig();
    }
    
    public PlayerSettings getPlayerSettings()
    {
        return playerSettings;
    }
    
    public void setPlayerName(string playerName)
    {
        this.playerName = playerName;
    }
}

