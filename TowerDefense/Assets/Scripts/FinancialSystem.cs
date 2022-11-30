using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinancialSystem
{
    private readonly TextMeshProUGUI _moneyLabel;

    private int Money { get; set; }

    public FinancialSystem(int startMoney)
    {
        this.Money = startMoney;
        _moneyLabel = GameObject.Find("MoneyLabel").GetComponent<TextMeshProUGUI>();
        UpdateUI();
    }

    public void GainMoney(int amount)
    {
        Money += amount;
        UpdateUI();
    }

    public bool TryBuy(int amount)
    {
        if (Money - amount < 0)
        {
            return false;
        }

        Money -= amount;
        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        _moneyLabel.text = $"Money: {Money}$";
    }
}