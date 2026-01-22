using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsTextBehavior : MonoBehaviour
{
    public static GameObject moonParentObj;
    public static GameObject sparkParentObj;
    public static GameObject rayParentObj;
    GameObject activeTower;
    TowerBehavior thisTowerScript;
    static bool startCheckVar = false;

    void Awake()
    {
        moonParentObj = GameObject.Find("UpgradeTowerMoon");
        sparkParentObj = GameObject.Find("UpgradeTowerSpark");
        rayParentObj = GameObject.Find("UpgradeTowerRay");
        startCheckVar = true;
    }

    void Update()
    {
        if (startCheckVar == true)
        {
            if (moonParentObj != null)
            {
                moonParentObj.SetActive(false);
            }
            else
            {
                Debug.Log("moonParentObj null");
            }
            if (sparkParentObj != null)
            {
                sparkParentObj.SetActive(false);
            }
            else
            {
                Debug.Log("sparkParentObj null");
            }
            if (rayParentObj != null)
            {
                rayParentObj.SetActive(false);
            }
            else
            {
                Debug.Log("rayParentObj null");
            }
            if (!moonParentObj.activeInHierarchy && !sparkParentObj.activeInHierarchy && !rayParentObj.activeInHierarchy)
            {
                startCheckVar = false;
            }
        }

        if (isActiveAndEnabled)
        {

            if (TowerBehavior.activeTowerExists)
            {
                activeTower = TowerBehavior.GetActiveTower();
                if (CompareTag("DamageStat"))
                {
                    thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                    GetComponent<TMP_Text>().SetText(thisTowerScript.bulletDamage.ToString());
                }
                else if (CompareTag("SpeedStat"))
                {
                    thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                    GetComponent<TMP_Text>().SetText(thisTowerScript.reloadTime.ToString());
                }
                else if (CompareTag("RangeStat"))
                {
                    thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                    GetComponent<TMP_Text>().SetText(thisTowerScript.rangeRadius.ToString());
                }
            }
        }

    }
}
