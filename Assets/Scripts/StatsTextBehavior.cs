using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsTextBehavior : MonoBehaviour
{
    TowerBehavior towerBehavior;
    GameObject activeTower;
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
                if(activeTower.name == "SparkTower(Clone)")
                {

                }
            }
            else if (CompareTag("SpeedStat"))
            {
                if (activeTower.name == "RayTower(Clone)")
                {

                }
            }
            else if (CompareTag("RangeStat"))
            {
                if (activeTower.name == "MoonTower(Clone)")
                {

                }
            }
        }
        
    }
        
}
