using GameHandling;
using NUnit.Framework;
using System.IO;
using UnityEngine.Android;

namespace Tests
{
    public class SettingsTests
    {
        private DirectoryInfo _settingsFolder;
        private string _settingFile;

        [SetUp]
        public void Init()
        {
            _settingsFolder = JsonFileHandler.GetSettingFolder();
            _settingFile = _settingsFolder.ToString() + Path.DirectorySeparatorChar + "Settings.json";
            if(File.Exists(_settingFile))  File.Delete(_settingFile);
            JsonFileHandler.Start();
        }
        
        [Test]
        public void SettingFileGenerationPasses()
        {
            Assert.IsTrue(File.Exists(_settingFile));
        }

        [Test]
        public void SettingsFileContentPasses()
        {
            bool emptyFile = new FileInfo(_settingFile).Length == 0;
            Assert.IsFalse(emptyFile);
        }
    }
}