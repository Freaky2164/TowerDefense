using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.WSA;

namespace GameHandling
{  
    [System.Serializable]
    public class WaveManagement : MonoBehaviour
    {
        [System.NonSerialized]
        private DirectoryInfo settingsFolder;
        [System.NonSerialized]
        private static string fileName = "WaveManagement.json";
        
        private Dictionary<int, Dictionary<string, int>> waves;
        
        public WaveManagement readFromJson()
        {
            if (!(settingsFolder is null))
            {
                string json = File.ReadAllText(settingsFolder.FullName + Path.DirectorySeparatorChar +  fileName);
                return JsonUtility.FromJson<WaveManagement>(json);
            }
            return null;
        }

        public void setSettingsFolder(DirectoryInfo settingsFolder)
        {
            this.settingsFolder = settingsFolder;
        }
    }
}