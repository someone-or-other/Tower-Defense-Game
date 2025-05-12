using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTowerButtonBehavior : MonoBehaviour
{
    public PlaceTowerBehavior PlaceMoonTowerBehavior;
    public PlaceTowerBehavior PlaceSparkTowerBehavior;
    public PlaceTowerBehavior PlaceShadowTowerBehavior;
    public PlaceTowerBehavior PlaceRayTowerBehavior;
    public GameObject buyMenu;
    void Start()
    {
        buyMenu.SetActive(false);
        
    }

    void Update()
    {
        
    }

    public void PressButtonBuy()
    {
        buyMenu.SetActive(true);
        Debug.Log("open menu");
        Time.timeScale = 0.0f;
    }

    public void PressButtonExitBuy()
    {
        Debug.Log("close menu");
        buyMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
