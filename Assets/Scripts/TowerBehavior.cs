using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    public int upgradeLevel = 0;
    public float rangeRadius;
    public float reloadTime;
    public GameObject bulletPrefab;
    public static GameObject modTowerMenu;


    private float elapsedTime;

    void Update()
    {
        if (elapsedTime >= reloadTime) {
        elapsedTime = 0;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);
        if (hitColliders.Length != 0)
        {
            float min = int.MaxValue;
            int index = -1;
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
    public void Upgrade()
    {
        rangeRadius += 1f;
        reloadTime -= 0.5f;
        upgradeLevel++;
        modTowerMenu.SetActive(false);
    }
    private void OnMouseDown()
    {
        modTowerMenu.SetActive(false );
        modTowerMenu.GetComponent<ModTowerBehavior>().currentTower = this;
        modTowerMenu.SetActive(true);
    }
}
