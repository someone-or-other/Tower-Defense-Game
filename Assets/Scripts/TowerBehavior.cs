using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public int upgradeLevel = 0;
    public float rangeRadius;
    public float reloadTime;
    public float bulletDamage;
    public float bulletSpeed;
    public static GameObject activeTower;
    public GameObject bulletPrefab;
    public static GameObject modTowerMenuMoon;
    public static GameObject modTowerMenuSpark;
    public static GameObject modTowerMenuRay;
    public bool targetFarthest;
    public GameObject bulletBehaviorObj;
    private float elapsedTime;
    public static bool activeTowerExists;
    private int thisDamage;
    public static GameObject moonPanel;
    public static GameObject sparkPanel;
    public static GameObject rayPanel;
    public StatsTextBehavior moonStats;
    public StatsTextBehavior sparkStats;
    public StatsTextBehavior rayStats;

    void Update()
    {
        
        if (elapsedTime >= reloadTime) {
            elapsedTime = 0;
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
            if (hitColliders.Length != 0)
            {
                int index = -1;
                if (!targetFarthest)
                {
                    float min = int.MaxValue;

                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        if (hitColliders[i].CompareTag("Enemy"))
                        {
                            float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                            if (distance < min)
                            {
                                index = i;
                                min = distance;
                            }
                        }
                    }
                }
                else
                {
                    float max = int.MinValue;

                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        if (hitColliders[i].CompareTag("Enemy"))
                        {
                            float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
                            if (distance > max)
                            {
                                index = i;
                                max = distance;
                            }
                        }
                    }
                }

                if (index == -1)
                {
                    return;
                }
                Transform target = hitColliders[index].transform;
                Vector2 direction = (target.position - transform.position).normalized;
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<BulletBehavior>().direction = direction;
            }
        }
        elapsedTime += Time.deltaTime;
    }

    public void Start()
    {
        moonPanel = StatsTextBehavior.moonParentObj;
        sparkPanel = StatsTextBehavior.sparkParentObj;
        rayPanel = StatsTextBehavior.rayParentObj;
        if(this.gameObject.name == "MoonTower(Clone)")
            moonPanel.SetActive(true);
        if(this.gameObject.name == "SparkTower(Clone)")
            sparkPanel.SetActive(true);
        if(this.gameObject.name == "RayTower(Clone)")
            rayPanel.SetActive(true);
    }

    public void Upgrade()
    {
        if (this.gameObject.name == "MoonTower(Clone)")
        {
            Debug.Log("MoonTower upgraded");
            reloadTime = 2;
            bulletDamage = 4;
            bulletSpeed = 12;
            rangeRadius = 20;
            bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletDamage(4);
            bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletSpeed(12);
        }
        else if (this.gameObject.name == "SparkTower(Clone)")
        {
            Debug.Log("SparkTower upgraded");
            reloadTime = 0.75f;
            bulletDamage = 2;
            bulletSpeed = 20;
            rangeRadius = 12;
            bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletDamage(2);
            bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletSpeed(20);

        }
        else if (this.gameObject.name == "RayTower(Clone)")
        {
            Debug.Log("RayTower upgraded");
            reloadTime = 6;
            bulletDamage = 8;
            bulletSpeed = 28;
            rangeRadius = 90;
            bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletDamage(8);
            bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletSpeed(28);
        }
        upgradeLevel++;
        modTowerMenuMoon.SetActive(false);
        modTowerMenuSpark.SetActive(false);
        modTowerMenuRay.SetActive(false);

    }
    private void OnMouseDown()
    {


        if (this.gameObject.name == "MoonTower(Clone)")
        {
            moonPanel.SetActive(true);
            activeTower = gameObject;
            Debug.Log("Moon Tower Clicked");
            moonPanel.SetActive(false);
            rayPanel.SetActive(false);
            sparkPanel.SetActive(false);
            moonPanel.GetComponent<ModTowerBehavior>().currentTower = this;
            Debug.Log("modtowermoon exists");
            moonPanel.SetActive(true);
            
        }
        else
        {
            moonPanel.SetActive(false);
        }
        if (this.gameObject.name == "SparkTower(Clone)")
        {
            sparkPanel.SetActive(true);
            activeTower = gameObject;
            Debug.Log("Spark Tower Clicked");
            moonPanel.SetActive(false);
            rayPanel.SetActive(false);
            sparkPanel.SetActive(false);
            sparkPanel.GetComponent<ModTowerBehavior>().currentTower = this;
            sparkPanel.SetActive(true);
        }
        else
        {
            sparkPanel.SetActive(false);
        }
        if (this.gameObject.name == "RayTower(Clone)")
        {
            rayPanel.SetActive(true);
            activeTower = gameObject;
            Debug.Log("Ray Tower Clicked");
            moonPanel.SetActive(false);
            rayPanel.SetActive(false);
            sparkPanel.SetActive(false);
            rayPanel.GetComponent<ModTowerBehavior>().currentTower = this;
            rayPanel.SetActive(true);
        }
        else
        {
            rayPanel.SetActive(false);
        }

    }

    public static GameObject GetActiveTower()
    {
        return activeTower;
    }

    public bool TowerExists()
    {
        if(activeTowerExists)
        {
            return true;
        }  
        return false;
    }

}
