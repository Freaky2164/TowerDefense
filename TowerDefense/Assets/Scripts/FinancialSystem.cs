using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinancialSystem
{
    private int money;
    private TextMeshProUGUI moneyLabel;

    public int Money
    {
        get => money;
        set
        {
            money = value;
            updateUI();
        }
    }

    public FinancialSystem(int startMoney)
    {
        this.money = startMoney;
        moneyLabel = GameObject.Find("MoneyLabel").GetComponent<TextMeshProUGUI>();
        updateUI();
    }

    public void gainMoney(int amount)
    {
        money += amount;
        updateUI();
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

    private void updateUI()
    {
        moneyLabel.text = "Money: " + money.ToString() + " $";
    }
}
