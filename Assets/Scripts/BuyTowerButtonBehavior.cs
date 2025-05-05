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
    }
}
