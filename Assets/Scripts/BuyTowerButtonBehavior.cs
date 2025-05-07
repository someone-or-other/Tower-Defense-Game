using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTowerButtonBehavior : MonoBehaviour
{
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
        Time.timeScale = 0.0f;
    }

    public void PressButtonExitBuy()
    {
        buyMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
