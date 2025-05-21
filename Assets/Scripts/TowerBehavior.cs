using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public int upgradeLevel = 0;
    public float rangeRadius;
    public float reloadTime;
    public GameObject bulletPrefab;
    public static GameObject modTowerMenuMoon;
    public static GameObject modTowerMenuSpark;
    public static GameObject modTowerMenuRay;
    public static GameObject moonPanel;
    public static GameObject sparkPanel;
    public static GameObject rayPanel;
    public bool targetFarthest;

    private float elapsedTime;

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
        
    }

    public void Upgrade()
    {
        rangeRadius += 1f;
        reloadTime -= 0.5f;
        upgradeLevel++;
        modTowerMenuMoon.SetActive(false);
        modTowerMenuSpark.SetActive(false);
        modTowerMenuRay.SetActive(false);
        moonPanel.SetActive(false);
        rayPanel.SetActive(false);
        sparkPanel.SetActive(false);

    }
    private void OnMouseDown()
    {
        //modTowerMenuMoon.SetActive(false);
        //modTowerMenuSpark.SetActive(false);
        //modTowerMenuRay.SetActive(false);
        if (this.gameObject.name == "MoonTower(Clone)")
        {
            Debug.Log("Moon Tower Clicked");
            modTowerMenuMoon.SetActive(false);
            moonPanel.SetActive(false);
            modTowerMenuMoon.GetComponent<ModTowerBehavior>().currentTower = this;
            Debug.Log("modtowermoon exists");
            modTowerMenuMoon.SetActive(true);
            moonPanel.SetActive(true);
        }
        if (this.gameObject.name == "SparkTower(Clone)")
        {
            Debug.Log("Spark Tower Clicked");
            modTowerMenuSpark.SetActive(false);
            sparkPanel.SetActive(false);
            modTowerMenuSpark.GetComponent<ModTowerBehavior>().currentTower = this;
            modTowerMenuSpark.SetActive(true);
            sparkPanel.SetActive(true);
        }
        if (this.gameObject.name == "RayTower(Clone)")
        {
            Debug.Log("Ray Tower Clicked");
            modTowerMenuRay.SetActive(false);
            rayPanel.SetActive(false);
            modTowerMenuRay.GetComponent<ModTowerBehavior>().currentTower = this;
            modTowerMenuRay.SetActive(true);
            rayPanel.SetActive(true);
        }

    }
}
