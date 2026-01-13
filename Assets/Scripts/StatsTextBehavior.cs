using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsTextBehavior : MonoBehaviour
{
    GameObject activeTower;
    TowerBehavior thisTowerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TowerBehavior.activeTowerExists);
        if(TowerBehavior.activeTowerExists)
        {
            activeTower = TowerBehavior.GetActiveTower();
            Debug.Log("Damage: " + CompareTag("DamageStat"));
            Debug.Log("Speed: " + CompareTag("SpeedStat"));
            Debug.Log("RangeStat: " + CompareTag("RangeStat"));
            if (CompareTag("DamageStat"))
            {
                thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                Debug.Log(thisTowerScript.bulletDamage);
                GetComponent<TMP_Text>().SetText(thisTowerScript.bulletDamage.ToString());
            }
            

            else if (CompareTag("SpeedStat"))
            {
                thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                Debug.Log(thisTowerScript.reloadTime);
                GetComponent<TMP_Text>().SetText(thisTowerScript.reloadTime.ToString());

            }
            else if (CompareTag("RangeStat"))
            {
                thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                Debug.Log(thisTowerScript.rangeRadius);
                GetComponent<TMP_Text>().SetText(thisTowerScript.rangeRadius.ToString());


            }
        }
        
    }
        
}
