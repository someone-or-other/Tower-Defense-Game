using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModTowerBehavior : MonoBehaviour
{
    MoneyCounterBehavior moneyCounter;

    [HideInInspector]
    public TowerBehavior currentTower;

    private Image menuImage;
    public TMP_Text upgradePriceText;
    public TMP_Text sellPriceText;

    [Header("Level 0 Settings")]
    public Sprite menuLevel0;
    public int upgradePriceLevel0;
    public int sellPriceLevel0;

    [Header("Level 1 Settings")]
    public Sprite menuLevel1;
    public int upgradePriceLevel1;
    public int sellPriceLevel1;

    [Header("Level 1 Settings")]
    public Sprite menuLevel2;
    public int sellPriceLevel2;

    private int level;
    private int currentUpgradePrice;
    private int currentSellPrice;

    void Awake()
    {
        moneyCounter = GameObject.Find("MoneyCounter").GetComponent<MoneyCounterBehavior>();
        menuImage = GetComponent<Image>();
        TowerBehavior.modTowerMenu = this.gameObject;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        if (!currentTower)
        {
            return;
        }
        level = currentTower.upgradeLevel;
        switch (level)
        {
            case 0:
                menuImage.sprite = menuLevel0;
                upgradePriceText.text = "$" + upgradePriceLevel0.ToString();
                currentUpgradePrice = upgradePriceLevel0;
                sellPriceText.text = "$" + sellPriceLevel0;
                currentSellPrice = sellPriceLevel0;
                break;
            case 1:
                menuImage.sprite = menuLevel1;
                upgradePriceText.text = "$" + upgradePriceLevel1.ToString();
                currentUpgradePrice = upgradePriceLevel1;
                sellPriceText.text = "$" + sellPriceLevel1;
                currentSellPrice = sellPriceLevel1;
                break;
            case 2:
                menuImage.sprite = menuLevel2;
                upgradePriceText.text = "-";
                sellPriceText.text = "$" + sellPriceLevel2;
                currentSellPrice = sellPriceLevel2;
                break;
        }
    }
    public void Upgrade()
    {
        if (level == 2)
        {
            return;
        }
        int money = moneyCounter.GetMoney();

        if (money >= currentUpgradePrice)
        {
            moneyCounter.ChangeMoney(-currentUpgradePrice);
            currentTower.Upgrade();
            gameObject.SetActive(false);
        }
    }
    public void Sell()
    {
        moneyCounter.ChangeMoney(currentSellPrice);
        Destroy(currentTower.gameObject);
        gameObject.SetActive(false);
    }

}
