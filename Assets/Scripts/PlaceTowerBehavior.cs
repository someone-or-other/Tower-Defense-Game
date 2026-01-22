using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceTowerBehavior : MonoBehaviour
{
    bool isPlacingTower;
    private GameManager gameManager;
    private BuyTowerBehavior buyMoonTowerBehaviorGameObject;
    private BuyTowerBehavior buySparkTowerBehaviorGameObject;
    private BuyTowerBehavior buyShadowTowerBehaviorGameObject;
    private BuyTowerBehavior buyRayTowerBehaviorGameObject;
    int thisTower = 0;
    public static GameObject canvas;



    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        canvas = GameObject.Find("Canvas");
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
                TowerBehavior.activeTower = gameObject;
                if (StatsTextBehavior.moonParentObj != null && StatsTextBehavior.sparkParentObj != null && StatsTextBehavior.rayParentObj != null)
                {
                        if (this.gameObject.name == "MoonTower(Clone)")
                        {
                            StatsTextBehavior.moonParentObj.SetActive(true);
                            StatsTextBehavior.sparkParentObj.SetActive(false);
                            StatsTextBehavior.rayParentObj.SetActive(false);
                        }
                        if (this.gameObject.name == "SparkTower(Clone)")
                        {
                            StatsTextBehavior.moonParentObj.SetActive(false);
                            StatsTextBehavior.sparkParentObj.SetActive(true);
                            StatsTextBehavior.rayParentObj.SetActive(false);
                        }
                        if (this.gameObject.name == "RayTower(Clone)")
                        {
                            StatsTextBehavior.moonParentObj.SetActive(false);
                            StatsTextBehavior.sparkParentObj.SetActive(false);
                            StatsTextBehavior.rayParentObj.SetActive(true);
                        }
                }
            }



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
}
