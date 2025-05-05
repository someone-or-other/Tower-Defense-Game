using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3[] waypoints;
    private LivesCounterBehavior livesCounter;

    private bool isAreaAllowed;
    public bool GetIsAreaAllowed()
    {
        return isAreaAllowed;
    }

    public GameObject enemyPrefab;
    public Vector3 SpawnPoint;

    public int enemyAmountToSpawn = 50;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f; 

    // Start is called before the first frame update
    void Start()
    {
        livesCounter = GameObject.Find("LivesCounter").GetComponent<LivesCounterBehavior>();
        StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
    }

    IEnumerator SpawnEnemies(int number)
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(enemyPrefab, SpawnPoint, Quaternion.identity);
            float ratio = i * 1f / (number - 1);
            float timeToWait = Mathf.Lerp(minSpawnTime, maxSpawnTime, 1-ratio);
            Debug.Log(timeToWait);
            yield return new WaitForSeconds(timeToWait);
        }

        bool isGameOver = false;

        while (!isGameOver)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                isGameOver = true;
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void EnemyHasReachedTheFortress(int damage)
    {
        livesCounter.LoseLife(damage);
        if (livesCounter.GetLives() <= 0)
        {
            StopCoroutine("SpawnEnemies");

        }
    }

    private void OnMouseEnter()
    {
        isAreaAllowed = true;
    }
    private void OnMouseExit()
    {
        isAreaAllowed = false;
    }

}
