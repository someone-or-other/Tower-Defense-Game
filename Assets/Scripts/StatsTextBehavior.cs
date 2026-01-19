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
    public static bool isProtectedMoon;
    public static bool isProtectedSpark;
    public static bool isProtectedRay;
    GameObject activeTower;
    TowerBehavior thisTowerScript;
    // Start is called before the first frame update
    void Start()
    {
        moonParentObj = GameObject.Find("UpgradeTowerMoon");
        sparkParentObj = GameObject.Find("UpgradeTowerSpark");
        rayParentObj = GameObject.Find("UpgradeTowerRay");
        if(!TowerBehavior.activeTowerExists)
        {
            moonParentObj.SetActive(false);
            sparkParentObj.SetActive(false);
            rayParentObj.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveAndEnabled)
        {

            //Debug.Log(TowerBehavior.activeTowerExists);
            if (TowerBehavior.activeTowerExists)
            {
                activeTower = TowerBehavior.GetActiveTower();
                //Debug.Log("Damage: " + CompareTag("DamageStat"));
                //Debug.Log("Speed: " + CompareTag("SpeedStat"));
                //Debug.Log("RangeStat: " + CompareTag("RangeStat"));
                if (CompareTag("DamageStat"))
                {
                    thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                    //Debug.Log(thisTowerScript.bulletDamage);
                    GetComponent<TMP_Text>().SetText(thisTowerScript.bulletDamage.ToString());
                }


                else if (CompareTag("SpeedStat"))
                {
                    thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                    //Debug.Log(thisTowerScript.reloadTime);
                    GetComponent<TMP_Text>().SetText(thisTowerScript.reloadTime.ToString());

                }
                else if (CompareTag("RangeStat"))
                {
                    thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                    //Debug.Log(thisTowerScript.rangeRadius);
                    GetComponent<TMP_Text>().SetText(thisTowerScript.rangeRadius.ToString());


                }
            }
        }
        
    }
}
