using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyTowerBehavior : MonoBehaviour
{
    public BuyTowerButtonBehavior BuyTowerButtonBehaviorScript;
    public PlaceTowerBehavior PlaceTowerBehaviorScript;
    MoneyCounterBehavior moneyCounter;

    public TMP_Text priceText;
    public int price;
    public GameObject towerPrefab;
    public bool isPlacingTower = false;
    public bool hasPlacedTower = false;

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
            isPlacingTower = true;
            Debug.Log("isPlacingTower");
            BuyTowerButtonBehaviorScript.buyMenu.SetActive(false);
            if (hasPlacedTower)
            {
                BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);

                PlaceTowerBehaviorScript = GameObject.Find("MoonTower").GetComponent<PlaceTowerBehavior>();
                BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
                hasPlacedTower = PlaceTowerBehaviorScript.GetFinishPlacingTower();
                if (hasPlacedTower)
                {
                    Debug.Log("has placed tower true");

                }
            }
        }
        else
        {
            Debug.Log("BROKE!!!!");
        }
    }

    private void Update()
    {
        if(isPlacingTower)
        hasPlacedTower = PlaceTowerBehaviorScript.GetFinishPlacingTower();
        if (hasPlacedTower)
        {
            BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
            hasPlacedTower = false;
        }
    }

    public bool GetIsPlacingTower()
    {
        if (isPlacingTower)
            return true;
        else
            return false;
    }

    public bool GetHasPlacedTower()
    {
        return hasPlacedTower;
    }
}
