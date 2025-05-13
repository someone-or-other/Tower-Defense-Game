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

    public GameObject basicEnemyPrefab;
    public GameObject speedEnemyPrefab;
    int speedEnemyCap = 20;
    public GameObject heavyEnemyPrefab;
    int heavyEnemyCap = 10;
    public GameObject supportEnemyPrefab;
    int supportEnemyCap = 5;

    public int currentRound = 0;
    public Vector3 SpawnPoint;

    public int enemyAmountToSpawn = 25;
    public int basicEnemiesSpawned = 0;
    public int speedEnemiesSpawned = 0;
    public int heavyEnemiesSpawned = 0;
    public int supportEnemiesSpawned = 0;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private int currentRound = 0;
    private bool isGameOver;

    private EnemyBehavior speedBehavior;
    private EnemyBehavior heavyBehavior;
    private EnemyBehavior supportBehavior;
    private EnemyBehavior basicBehavior;

    private int round = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesCounter = GameObject.Find("LivesCounter").GetComponent<LivesCounterBehavior>();
        StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
    }

    IEnumerator SpawnEnemies(int number)
    {
        speedBehavior = speedEnemyPrefab.GetComponent<EnemyBehavior>();
        heavyBehavior = speedEnemyPrefab.GetComponent<EnemyBehavior>();
        supportBehavior = speedEnemyPrefab.GetComponent<EnemyBehavior>();
        basicBehavior = speedEnemyPrefab.GetComponent<EnemyBehavior>();

        speedBehavior.updateMoney(round);
        heavyBehavior.updateMoney(round);
        supportBehavior.updateMoney(round);
        basicBehavior.updateMoney(round);

        for (int i = 0; i < number; i++)
        {
            int random = Random.Range(0, 7);
            Debug.Log(random);
            if (random == 0 && speedEnemiesSpawned < speedEnemyCap)
            {
                Instantiate(speedEnemyPrefab, SpawnPoint, Quaternion.identity);
                speedEnemiesSpawned++;
            }
            else if (random == 1 && heavyEnemiesSpawned < heavyEnemyCap)
            {
                Instantiate(heavyEnemyPrefab, SpawnPoint, Quaternion.identity);
                heavyEnemiesSpawned++;
            }
            else if (random < 3 && supportEnemiesSpawned < supportEnemyCap)
            {
                Instantiate(supportEnemyPrefab, SpawnPoint, Quaternion.identity);
                supportEnemiesSpawned++;
            }
            else
            {
                Instantiate(basicEnemyPrefab, SpawnPoint, Quaternion.identity);
            }
            float ratio = i * 1f / (number - 1);
            float timeToWait = Mathf.Lerp(minSpawnTime, maxSpawnTime, 1-ratio);
            Debug.Log(timeToWait);
            yield return new WaitForSeconds(timeToWait);
        }

        isGameOver = false;

        while (!isGameOver)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                isGameOver = true;
                round++;
                yield return new WaitForSeconds(10);
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
    private void Update()
    {
        if (isGameOver)
        {
            Debug.Log("Skib New Round");
            enemyAmountToSpawn += 10;
            // minSpawnTime += 1f;
            StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
            isGameOver = false;
        }
    }
}
