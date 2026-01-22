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

    
    public Image menuImage;
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
    private int currentUpgradePrice = 500;
    private int currentSellPrice = 450;

    

    void Awake()
    {
        moneyCounter = GameObject.Find("MoneyCounterText").GetComponent<MoneyCounterBehavior>();
        menuImage = GetComponent<Image>();
        if (this.gameObject.name == "moonUpgradePanel")
        {
            TowerBehavior.modTowerMenuMoon = this.gameObject;
        }
        if (this.gameObject.name == "sparkUpgradePanel")
        {
            TowerBehavior.modTowerMenuSpark = this.gameObject;
        }
        if (this.gameObject.name == "rayUpgradePanel")
        {
            TowerBehavior.modTowerMenuRay = this.gameObject;

        }
    }
    private void OnEnable()
    {
        
    }
    public void Upgrade()
    {
        currentTower = TowerBehavior.GetActiveTower().GetComponent<TowerBehavior>();
        if (level == 2)
        {
            return;
        }
        int money = moneyCounter.GetMoney();

        if (money >= currentUpgradePrice)
        {
            Debug.Log(currentUpgradePrice);
            Debug.Log(money);
            moneyCounter.ChangeMoney(-currentUpgradePrice);
            currentTower.Upgrade();
            gameObject.SetActive(false);
            //panelScript.Close();


        if (!currentTower)
        {
            return;
        }
        currentTower = TowerBehavior.GetActiveTower().GetComponent<TowerBehavior>();
        level = currentTower.upgradeLevel;
        Debug.Log(level + "aaaaaaaaaaaaaaaaaaaaaaaahhhh!!!!!");
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
    }
    public void Sell()
    {
        currentTower = TowerBehavior.GetActiveTower().GetComponent<TowerBehavior>();

        if (currentTower.name == "MoonTower(Clone)")
        {
            StatsTextBehavior.moonParentObj.SetActive(false);
        }
        else if (currentTower.name == "SparkTower(Clone)")
        {
            StatsTextBehavior.sparkParentObj.SetActive(false);
        }
        else if (currentTower.name == "RayTower(Clone)")
        {
            StatsTextBehavior.rayParentObj.SetActive(false);
        }
        moneyCounter.ChangeMoney(currentSellPrice);
        Destroy(currentTower.gameObject);
        
    }

}
