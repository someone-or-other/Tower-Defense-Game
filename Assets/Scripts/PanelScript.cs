using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    private void Awake()
    {
        if (this.gameObject.name == "PanelMoon")
        {
            TowerBehavior.moonPanel = this.gameObject;
            gameObject.SetActive(false);
        }
        if (this.gameObject.name == "PanelSpark")
        {
            TowerBehavior.sparkPanel = this.gameObject;
            gameObject.SetActive(false);
        }
        if (this.gameObject.name == "PanelRay")
        {
            TowerBehavior.rayPanel = this.gameObject;
            gameObject.SetActive(false);

        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
