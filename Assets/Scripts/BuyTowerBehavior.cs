using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyTowerBehavior : MonoBehaviour
{
    public BuyTowerButtonBehavior BuyTowerButtonBehaviorScript;
    public PlaceTowerBehavior PlaceTowerBehaviorScript;
    public MoneyCounterBehavior moneyCounter;

    public TMP_Text priceText;
    public int price;
    public GameObject towerPrefab;
    public bool isPlacingTower = false;
    public bool hasPlacedTower = false;

    private void Start()
    {
        
        //moneyCounter = GameObject.Find("MoneyCounterText").GetComponent<MoneyCounterBehavior>();
        priceText.text = "$" + price;
        Debug.Log(gameObject.name);
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
            BuyTowerButtonBehaviorScript.buyingPanel.SetActive(true);
            if (!isPlacingTower)
            {
                BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
                BuyTowerButtonBehaviorScript.buyingPanel.SetActive(false);

                PlaceTowerBehaviorScript = GameObject.Find("MoonTower").GetComponent<PlaceTowerBehavior>();
                BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
              //  hasPlacedTower = PlaceTowerBehaviorScript.GetFinishPlacingTower();
                if (!isPlacingTower)
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

        if (!isPlacingTower)
        {
            BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
            BuyTowerButtonBehaviorScript.buyingPanel.SetActive(false);
        }

    }

    public bool GetIsPlacingTower()
    {
        if (isPlacingTower)
            return true;
        else
            return false;
    }


    }
