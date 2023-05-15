using GameHandling;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthLabel : MonoBehaviour
    {
        private TextMeshProUGUI _label;

        private void Start()
        {
            _label = GetComponent<TextMeshProUGUI>();
            GameHandler.I.Player.HealthChanged += OnPlayerHealthChanged;
        }

        private void OnPlayerHealthChanged(int health)
        {
            _label.text = $"Health: {health}";
        }
    }
}
