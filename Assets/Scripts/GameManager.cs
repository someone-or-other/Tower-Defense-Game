using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject bossPrefab;
    bool bossCap = false;

    public int currentRound = 0;
    public Vector3 SpawnPoint;

    public int enemyAmountToSpawn = 25;
    public int basicEnemiesSpawned = 0;
    public int speedEnemiesSpawned = 0;
    public int heavyEnemiesSpawned = 0;
    public int supportEnemiesSpawned = 0;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private bool isGameOver = true;

    private EnemyBehavior speedBehavior;
    private EnemyBehavior heavyBehavior;
    private EnemyBehavior supportBehavior;
    private EnemyBehavior basicBehavior;
    private EnemyBehavior bossBehavior;

    public TMP_Text roundText;

    private int round = 0;

    // Start is called before the first frame update
    void Start()
    {
        livesCounter = GameObject.Find("LivesCounter").GetComponent<LivesCounterBehavior>();
        roundText.text = "Round: " + round.ToString();
        //StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
    }

    IEnumerator SpawnEnemies(int number)
    {
        speedBehavior = speedEnemyPrefab.GetComponent<EnemyBehavior>();
        heavyBehavior = heavyEnemyPrefab.GetComponent<EnemyBehavior>();
        supportBehavior = supportEnemyPrefab.GetComponent<EnemyBehavior>();
        basicBehavior = basicEnemyPrefab.GetComponent<EnemyBehavior>();
        bossBehavior = bossPrefab.GetComponent<EnemyBehavior>();

        speedBehavior.updateMoney(round);
        heavyBehavior.updateMoney(round);
        supportBehavior.updateMoney(round);
        basicBehavior.updateMoney(round);
        bossBehavior.updateMoney(round);

        for (int i = 0; i < number; i++)
        {
            int random = Random.Range(0, round/2 + 1);
            Debug.Log(random);
            if (random == 1 && speedEnemiesSpawned < speedEnemyCap)
            {
                Instantiate(speedEnemyPrefab, SpawnPoint, Quaternion.identity);
                speedEnemiesSpawned++;
            }
            else if (random == 2 && heavyEnemiesSpawned < heavyEnemyCap)
            {
                Instantiate(heavyEnemyPrefab, SpawnPoint, Quaternion.identity);
                heavyEnemiesSpawned++;
            }
            else if (random < 4 && supportEnemiesSpawned < supportEnemyCap)
            {
                Instantiate(supportEnemyPrefab, SpawnPoint, Quaternion.identity);
                supportEnemiesSpawned++;
            }
            else if(random > 6 && bossCap)
            {
                Instantiate(bossPrefab, SpawnPoint, Quaternion.identity);
                bossCap = true;
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
        bossCap = false;
        while (!isGameOver)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                isGameOver = true;

                yield return new WaitForSeconds(1);
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

    public void nextRound()
    {
        if (isGameOver)
        {
            isGameOver = false;
            Debug.Log("Skib New Round");
            enemyAmountToSpawn += 10;
            // minSpawnTime += 1f;
            round++;
            roundText.text = "Round: " + round.ToString();
            StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
        }
    }
}
