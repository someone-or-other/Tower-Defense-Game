using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyTowerBehavior : MonoBehaviour
{
    MoneyCounterBehavior moneyCounter;

    public TMP_Text priceText;
    public int price;
    public GameObject towerPrefab;

    private void Start()
    {
        moneyCounter = GameObject.Find("MoneyCounter").GetComponent<MoneyCounterBehavior>();
        priceText.text = "$" + price;
    }

    public void OnClick()
    {
        int money = moneyCounter.GetMoney();
        if (money >= price)
        {
            moneyCounter.ChangeMoney(-price);
            Instantiate(towerPrefab, Input.mousePosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("BROKE!!!!");
        }
    }
}
