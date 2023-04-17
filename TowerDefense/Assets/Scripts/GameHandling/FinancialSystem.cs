using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinancialSystem
{
    private readonly TextMeshProUGUI moneyLabel;

    private int money;

    public FinancialSystem(int startMoney)
    {
        money = startMoney;
        moneyLabel = GameObject.Find("MoneyLabel").GetComponent<TextMeshProUGUI>();
        UpdateUI();
    }

    public void GainMoney(int amount)
    {
        money += amount;
        UpdateUI();
    }

    public bool TryBuy(int amount)
    {
        if (money - amount < 0)
        {
            return false;
        }

        money -= amount;
        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        moneyLabel.text = $"Money: {money}$";
    }
}