using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowerBehavior : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 7));

        if (Input.GetMouseButtonDown(0) && gameManager.GetIsAreaAllowed())
        {
            GetComponent<TowerBehavior>().enabled = true;
            gameObject.AddComponent<BoxCollider2D>();
            Destroy(this);
        }
    }
}
