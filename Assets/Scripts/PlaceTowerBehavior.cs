using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceTowerBehavior : MonoBehaviour
{
    bool isPlacingTower;
    bool hasPlacedTower = false;
    private GameManager gameManager;
    private BuyTowerBehavior buyMoonTowerBehaviorGameObject;
    private BuyTowerBehavior buySparkTowerBehaviorGameObject;
    private BuyTowerBehavior buyShadowTowerBehaviorGameObject;
    private BuyTowerBehavior buyRayTowerBehaviorGameObject;
    int thisTower = 0;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        if (gameObject.name == "MoonTower(Clone)")
        {
            thisTower = 1;
            buyMoonTowerBehaviorGameObject = GameObject.Find("ButtonMoonEmpty").GetComponent<BuyTowerBehavior>();

        }
        if (gameObject.name == "SparkTower(Clone)")
        {
            buySparkTowerBehaviorGameObject = GameObject.Find("ButtonSparkEmpty").GetComponent<BuyTowerBehavior>();
            thisTower = 2;
        }
        if (gameObject.name == "RayTower(Clone)")
        {
            buyRayTowerBehaviorGameObject = GameObject.Find("ButtonRayEmpty").GetComponent<BuyTowerBehavior>();
            thisTower = 3;
        }
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));

        if (Input.GetMouseButtonDown(0) && gameManager.GetIsAreaAllowed())
        {
            GetComponent<TowerBehavior>().enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            if (thisTower == 1)
            {
                isPlacingTower = buyMoonTowerBehaviorGameObject.GetIsPlacingTower();
                buyMoonTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
                buyMoonTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyingPanel.SetActive(false);
            }
            if (thisTower == 2)
            {
                isPlacingTower = buySparkTowerBehaviorGameObject.GetIsPlacingTower();
                buySparkTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
                buySparkTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyingPanel.SetActive(false);
            }
            if (thisTower == 3)
            {
                isPlacingTower = buyRayTowerBehaviorGameObject.GetIsPlacingTower();
                buyRayTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
                buyRayTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyingPanel.SetActive(false);
            }

            if (isPlacingTower)
            {
                Debug.Log("placed");
                TowerBehavior.activeTowerExists = true;
            }
            hasPlacedTower = true;

            isPlacingTower = false;
            Destroy(this);
        }
        /*
        if(buyMoonTowerBehaviorGameObject.GetHasPlacedTower())
        {
            Debug.Log("destroy");
            Destroy(this);
        }
        */
    }


    public bool GetFinishPlacingTower()
    {
        return hasPlacedTower;
    }
}
