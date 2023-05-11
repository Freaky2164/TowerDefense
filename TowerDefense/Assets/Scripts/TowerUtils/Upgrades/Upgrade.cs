using System;
using GameHandling;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TowerUtils.Upgrades
{
    public class Upgrade: MonoBehaviour
    { 
        public Action<BaseTower> UpgradeAction { get; set; } 
        public int Cost;
        private Image _image;
        [CanBeNull] public BaseTower _tower;
        public GameObject menu;
        private UpgradeMenu _parentScript;

        public bool IsInitialized { get; private set;}

        public Upgrade(Action<BaseTower> action, int cost)
        {
            UpgradeAction = action;
            Cost = cost;
        }

        private void Start()
        {
            _parentScript = menu.GetComponent<UpgradeMenu>();
            IsInitialized = true;
            _image = Resources.Load("Icons/d_SplineComponent") as Image;
        }

        public void SetUpgrade(Upgrade upgrade)
        {
            UpgradeAction = upgrade.UpgradeAction;
            Cost = upgrade.Cost;
        }

        public void PerformAction()
        {
            if (!GameHandler.I.Finances.TryBuy(Cost)) return;
            UpgradeAction.Invoke(_tower); 
            _parentScript.NextUpgrade(gameObject);
        }
    }
}