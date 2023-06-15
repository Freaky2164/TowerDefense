using System;
using GameHandling;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TowerUtils.Upgrades
{
    public class Upgrade: MonoBehaviour
    { 
        public Action<BaseTower> UpgradeAction { get; set; } 
        private int _cost;
        private String _name;
        [CanBeNull] public BaseTower _tower;
        public GameObject menu;
        private UpgradeMenu _parentScript;
        private TextMeshProUGUI _costLabel;
        private TextMeshProUGUI _nameLabel;

        public bool IsInitialized { get; private set;}

        public Upgrade(Action<BaseTower> action, int cost, String name)
        {
            UpgradeAction = action;
            _cost = cost;
            _name = name;
        }

        private void Start()
        {
            _parentScript = menu.GetComponent<UpgradeMenu>();
            IsInitialized = true;
            var etst = transform.GetChild(0);
            _costLabel = etst.gameObject.GetComponent<TextMeshProUGUI>();
            var ezua = transform.GetChild(1);
            _nameLabel =ezua.gameObject.GetComponent<TextMeshProUGUI>();
        }

        public void SetUpgrade(Upgrade upgrade)
        {
            UpgradeAction = upgrade.UpgradeAction;
            _cost = upgrade._cost;
            _name = upgrade._name;
            SetLabels();
        }

        public void PerformAction()
        {
            if (!GameHandler.I.Finances.TryBuy(_cost)) return;
            UpgradeAction.Invoke(_tower); 
            _parentScript.NextUpgrade(gameObject);
        }

        private void SetLabels()
        {
            _costLabel.text = "Cost: " + _cost;
            _nameLabel.text = _name;
        }

        public void RemoveUpgrade()
        {
            _cost = 0;
            _name = "Kein Turm ausgewählt";
            UpgradeAction = DoesNothing;
            SetLabels();
        }
        
        void DoesNothing(BaseTower arg1)
        {
        }
    }
}