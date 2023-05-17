using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameHandling
{
    [System.Serializable]
    public class SkillTree
    {
        [System.NonSerialized]
        public static string FileName = "SkillTree.json";
        
        public int currentEXP;
        public List<jsonListImp> militaery;
        public List<jsonListImp> special;

        public SkillTree()
        {
            CreateDefaultValues();
        }
        
        
        public void CreateDefaultValues()
        {
            currentEXP = 0;
            createMilitaery();
            createSpezial();
        }

        private void createMilitaery()
        {
            militaery = new List<jsonListImp>();
            militaery.Add(new jsonListImp("pirateBonusMoney", false));
            militaery.Add(new jsonListImp("sniperAttackspeed", false));
            militaery.Add(new jsonListImp("dmgBonusSniper", false));
            militaery.Add(new jsonListImp("dmgBonusAssultRifel", false));
            militaery.Add(new jsonListImp("sniperASQuickScope", false));
        }
        private void createSpezial()
        {
            special = new List<jsonListImp>();
            special.Add(new jsonListImp("cheaperBigMom", false));
            special.Add(new jsonListImp("fireMageAOE", false));
            special.Add(new jsonListImp("lightMageBonusEnemyHits", false));
            special.Add(new jsonListImp("lightMageMageHigherRW", false));
            special.Add(new jsonListImp("bonusMoneyOnEnemyKill", false));
        }
        
        public void SaveToJson()
        {
            if (!(JsonFileHandler.GameConfigurationFolder is null))
            {
                var json = JsonUtility.ToJson(this);
                File.WriteAllText(JsonFileHandler.GameConfigurationFolder.FullName + Path.DirectorySeparatorChar + FileName, json);
            }
        }
        
        public static SkillTree readFromJson()
        {
            if (!(JsonFileHandler.GameConfigurationFolder is null))
            {
                string json = File.ReadAllText(JsonFileHandler.GameConfigurationFolder.FullName + Path.DirectorySeparatorChar +  FileName);
                return JsonUtility.FromJson<SkillTree>(json);
            }
            return null;
        }

        public List<jsonListImp> getMilitaery()
        {
            return militaery;
        }
        
        public List<jsonListImp> getSpecial()
        {
            return special;
        }
    }
}