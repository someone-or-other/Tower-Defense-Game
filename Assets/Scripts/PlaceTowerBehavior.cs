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

    private AudioSource source;
    public AudioClip placing;

    void Start()
    {
        source = GameObject.Find("Audio").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        buyMoonTowerBehaviorGameObject = GameObject.Find("ButtonMoonEmpty").GetComponent<BuyTowerBehavior>();
        buySparkTowerBehaviorGameObject = GameObject.Find("ButtonSparkEmpty").GetComponent<BuyTowerBehavior>();
        buyShadowTowerBehaviorGameObject = GameObject.Find("ButtonShadowEmpty").GetComponent<BuyTowerBehavior>();
        buyRayTowerBehaviorGameObject = GameObject.Find("ButtonRayEmpty").GetComponent<BuyTowerBehavior>();
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));

        if (Input.GetMouseButtonDown(0) && gameManager.GetIsAreaAllowed())
        {
            GetComponent<TowerBehavior>().enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            isPlacingTower = buyMoonTowerBehaviorGameObject.GetIsPlacingTower();
            if (isPlacingTower)
            {
                Debug.Log("placed");
                buyMoonTowerBehaviorGameObject.BuyTowerButtonBehaviorScript.buyMenu.SetActive(true);
            }
            hasPlacedTower = true;
            source.PlayOneShot(placing);
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
