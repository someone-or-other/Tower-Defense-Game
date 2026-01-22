using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static GameObject moonParentObj;
    public static GameObject sparkPanel;
    public static GameObject rayPanel;
    public Sprite moonTowerSpriteLv2;
    public Sprite moonTowerSpriteLv3;
    public Sprite sparkTowerSpriteLv2;
    public Sprite sparkTowerSpriteLv3;
    public Sprite rayTowerSpriteLv2;
    public Sprite rayTowerSpriteLv3;
    public Animator moonAnimator;
    public Animator sparkAnimator;
    public Animator rayAnimator;
    public Image towerImage;

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

    public void Awake()
    {
        if (this.gameObject.name == "MoonTower(Clone)")
        {
            towerImage = StatsTextBehavior.moonImage;
            this.bulletDamage = 2;
        }
        else if (this.gameObject.name == "SparkTower(Clone)")
        {
            towerImage = StatsTextBehavior.sparkImage;
            this.bulletDamage = 1;
        }
        else if (this.gameObject.name == "RayTower(Clone)")
        {
            towerImage = StatsTextBehavior.rayImage;
            this.bulletDamage = 4;
        }
        
        //-------------------------------------------------

        if (StatsTextBehavior.moonParentObj != null && StatsTextBehavior.sparkParentObj != null && StatsTextBehavior.rayParentObj != null)
        {
            Debug.Log("All Parent Obj NOT null");
        }
        else if (StatsTextBehavior.moonParentObj != null && StatsTextBehavior.sparkParentObj != null)
        {
            Debug.Log("Moon Parent Obj & Spark Parent Obj NOT null -> Ray Parent Obj null");
        }
        else if (StatsTextBehavior.moonParentObj != null && StatsTextBehavior.rayParentObj != null)
        {
            Debug.Log("Moon Parent Obj & Ray Parent Obj NOT null -> Spark Parent Obj null");
        }
        else if (StatsTextBehavior.sparkParentObj != null && StatsTextBehavior.rayParentObj != null)
        {
            Debug.Log("Spark Parent Obj & Ray Parent Obj NOT null -> Moon Parent Obj null");
        }
        else if (StatsTextBehavior.moonParentObj != null)
        {
            Debug.Log("Only Moon Parent Obj NOT null");
        }
        else if (StatsTextBehavior.sparkParentObj != null)
        {
            Debug.Log("Only Spark Parent Obj NOT null");
        }
        else if (StatsTextBehavior.rayParentObj != null)
        {
            Debug.Log("Only Ray Parent Obj NOT null");
        }
        else if (StatsTextBehavior.moonParentObj == null && StatsTextBehavior.sparkParentObj == null && StatsTextBehavior.rayParentObj == null)
        {
            Debug.Log("Very Broken, all Parent Objs are null");
        }
        else
        {
            Debug.Log("??? How???");
        }
    }

    public void Upgrade()
    {
        upgradeLevel++;

        //---------------------------------------------------------


        if (this.gameObject.name == "MoonTower(Clone)")
        {
            Debug.Log("MoonTower upgraded");
            moonAnimator.SetInteger("UpgradeLv", upgradeLevel);
            if(upgradeLevel == 1)
            {
                StatsTextBehavior.moonImage.sprite = moonTowerSpriteLv2;
                rangeRadius = 20;
                reloadTime = 2;
                bulletDamage = 5;
                bulletSpeed = 12;
                this.GetComponent<SpriteRenderer>().sprite = moonTowerSpriteLv2;
            }
            else if(upgradeLevel == 2)
            {
                StatsTextBehavior.moonImage.sprite = moonTowerSpriteLv3;
                //Overall improvement
                rangeRadius = 30;
                reloadTime = 1;
                bulletDamage = 7;
                bulletSpeed = 20;
                this.GetComponent<SpriteRenderer>().sprite = moonTowerSpriteLv3;

            }
        }
        else if (this.gameObject.name == "SparkTower(Clone)")
        {
            sparkAnimator.SetInteger("UpgradeLv", upgradeLevel);
            Debug.Log("SparkTower upgraded");
            if(upgradeLevel == 1)
            {
                StatsTextBehavior.sparkImage.sprite = sparkTowerSpriteLv2;
                rangeRadius = 14;
                reloadTime = .75f;
                bulletDamage = 4;
                bulletSpeed = 20;
                this.GetComponent<SpriteRenderer>().sprite = sparkTowerSpriteLv2;
            }
            else if(upgradeLevel == 2)
            {
                StatsTextBehavior.sparkImage.sprite = sparkTowerSpriteLv3;
                //incredibly fast
                rangeRadius = 17;
                reloadTime = .4f;
                bulletDamage = 5;
                bulletSpeed = 20;
                this.GetComponent<SpriteRenderer>().sprite = sparkTowerSpriteLv3;
            }
        }
        else if (this.gameObject.name == "RayTower(Clone)")
        {
            rayAnimator.SetInteger("UpgradeLv", upgradeLevel);
            //lots of damage but even slower
            Debug.Log("RayTower upgraded");
            if (upgradeLevel == 1)
            {
                StatsTextBehavior.rayImage.sprite = rayTowerSpriteLv2;
                rangeRadius = 90;
                reloadTime = 6;
                bulletDamage = 8;
                bulletSpeed = 28;
                this.GetComponent<SpriteRenderer>().sprite = rayTowerSpriteLv2;
            }
            else if (upgradeLevel == 2)
            {
                StatsTextBehavior.rayImage.sprite = rayTowerSpriteLv3;
                rangeRadius = 90;
                reloadTime = 7;
                bulletDamage = 15;
                bulletSpeed = 30;
                this.GetComponent<SpriteRenderer>().sprite = rayTowerSpriteLv3;
            }
        }
        bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletDamage((int)bulletDamage);
        bulletBehaviorObj.GetComponent<BulletBehavior>().SetBulletSpeed((int)bulletSpeed);
    }
    private void OnMouseDown()
    {


        if (this.gameObject.name == "MoonTower(Clone)")
        {
            StatsTextBehavior.moonParentObj.SetActive(true);
            StatsTextBehavior.rayParentObj.SetActive(false);
            StatsTextBehavior.sparkParentObj.SetActive(false);
            activeTower = gameObject;
            Debug.Log("Moon Tower Clicked");
            StatsTextBehavior.moonParentObj.GetComponent<ModTowerBehavior>().currentTower = this;
            Debug.Log("modtowermoon exists");

        }
        else
        {
            StatsTextBehavior.moonParentObj.SetActive(false);
        }
        if (this.gameObject.name == "SparkTower(Clone)")
        {
            StatsTextBehavior.sparkParentObj.SetActive(true);
            StatsTextBehavior.moonParentObj.SetActive(false);
            StatsTextBehavior.rayParentObj.SetActive(false);
            activeTower = gameObject;
            Debug.Log("Spark Tower Clicked");
            StatsTextBehavior.sparkParentObj.GetComponent<ModTowerBehavior>().currentTower = this;
        }
        else
        {
            StatsTextBehavior.sparkParentObj.SetActive(false);
        }
        if (this.gameObject.name == "RayTower(Clone)")
        {
            StatsTextBehavior.rayParentObj.SetActive(true);
            StatsTextBehavior.moonParentObj.SetActive(false);
            StatsTextBehavior.sparkParentObj.SetActive(false);
            activeTower = gameObject;
            Debug.Log("Ray Tower Clicked");
            StatsTextBehavior.rayParentObj.GetComponent<ModTowerBehavior>().currentTower = this;
        }
        else
        {
            StatsTextBehavior.rayParentObj.SetActive(false);
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
