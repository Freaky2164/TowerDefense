
using System;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI healthLabel;
    public int maxHealth;
    
    public event Action PlayerDied;

    private int _health;

    private void Start()
    {
        _health = maxHealth;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0) RaisePlayerDied();
        UpdateUI();
    }

    private void UpdateUI()
    {
        healthLabel.text = $"Health: {_health}";
    }

    private void RaisePlayerDied()
    {
        PlayerDied?.Invoke();
    }
}