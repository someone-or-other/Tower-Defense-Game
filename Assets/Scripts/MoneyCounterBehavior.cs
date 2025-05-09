using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyCounterBehavior : MonoBehaviour
{
    private TMP_Text moneyText;
    private int money = 3000;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GetComponentInChildren<TMP_Text>();
        UpdateMoneyCounter();
    }
    public void ChangeMoney(int amount)
    {
        money += amount;
        if (money < 0)
        {
            money = 0;
        }
        UpdateMoneyCounter();
    }
    public int GetMoney()
    {
        return money;
    }
    // Update is called once per frame
    private void UpdateMoneyCounter()
    {
        moneyText.text = "$" + money;
    }
}
