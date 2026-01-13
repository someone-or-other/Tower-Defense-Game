using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour
{
    /*
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

    public void Close()
    {
        if (this.gameObject.name == "PanelMoon")
        {
            TowerBehavior.moonPanel = this.gameObject;
            gameObject.SetActive(false);
            Debug.Log('a');

        }
        if (this.gameObject.name == "PanelSpark")
        {
            TowerBehavior.sparkPanel = this.gameObject;
            gameObject.SetActive(false);
            Debug.Log('b');

        }
        if (this.gameObject.name == "PanelRay")
        {
            TowerBehavior.rayPanel = this.gameObject;
            gameObject.SetActive(false);
            Debug.Log('c');
        }


    }
    */
    public void OnMouseDown()
    {
        Debug.Log("MouseDown");
        if(this.gameObject.name != "PanelMoon")
        {
            Debug.Log("not moon panel");
            if(this.gameObject.name != "PanelRay")
            {
                Debug.Log("Not Ray panel");
                if(this.gameObject.name != "PanelSpark")
                {
                    Debug.Log("Not spark tower");
                    gameObject.SetActive(false);
                }
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
