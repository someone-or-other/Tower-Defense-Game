using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTextBehavior : MonoBehaviour
{
    public TowerBehavior towerBehavior;
    GameObject activeTower;
    TowerBehavior thisTowerScript;
    public GameObject damageText;
    public GameObject speedText;
    public GameObject rangeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(towerBehavior.TowerExists())
        {
            activeTower = towerBehavior.GetActiveTower();
            if (CompareTag("DamageStat"))
            {
                thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                damageText.GetComponent<Text>().text = thisTowerScript.bulletDamage.ToString();
            }
            else if (CompareTag("SpeedStat"))
            {
                thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                speedText.GetComponent<Text>().text = thisTowerScript.reloadTime.ToString();

            }
            else if (CompareTag("RangeStat"))
            {
                thisTowerScript = activeTower.GetComponent<TowerBehavior>();
                rangeText.GetComponent<Text>().text = thisTowerScript.rangeRadius.ToString();


            }
        }
        
    }
        
}
