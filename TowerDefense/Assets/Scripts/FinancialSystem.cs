using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinancialSystem
{
    private int money;
    private TextMeshProUGUI moneyLabel;

    public FinancialSystem(int startMoney)
    {
        this.money = startMoney;
        moneyLabel = GameObject.Find("MoneyLabel").GetComponent<TextMeshProUGUI>();
        Debug.Log(moneyLabel);
        updateUI();
    }

    public void gainMoney(int amount)
    {
        money += amount;
        updateUI();
    }

    private void updateUI()
    {
        moneyLabel.text = money.ToString();
    }

    public bool buy(int amount)
    {
        if (money - amount > 0)
        {
            return false;
        }
        money -= amount;
        updateUI();
        return true;
    }
}
