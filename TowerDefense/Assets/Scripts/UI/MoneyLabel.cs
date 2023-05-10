using GameHandling;
using TMPro;
using UnityEngine;

namespace UI
{
    public class MoneyLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;

        private void Start()
        {
            _label = GetComponent<TextMeshProUGUI>();
        }

        private void OnMoneyChanged(int money)
        {
            _label.text = $"Money: {money}$";
        }
    }
}