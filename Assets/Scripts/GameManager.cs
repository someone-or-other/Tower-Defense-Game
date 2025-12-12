using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3[] waypoints;
    public LivesCounterBehavior livesCounter;

    private int speedCycleVar = 0;
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

    public int enemyAmountToSpawn = 5;
    public int basicEnemiesSpawned = 0;
    public int speedEnemiesSpawned = 0;
    public int heavyEnemiesSpawned = 0;
    public int supportEnemiesSpawned = 0;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private bool isGameOver = true;
    private bool isDead = false;

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
       isDead = false;
        roundText.text = "Round: " + round.ToString();
        //StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
        speedCycleVar = 0;
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
            int random;
            if (round > 3)
            {
                random = Random.Range(1, 7);
            }
            else
            {
                random = Random.Range(1, round * 2);
            }
             
            if (random == 2 && speedEnemiesSpawned < speedEnemyCap)
            {
                Instantiate(speedEnemyPrefab, SpawnPoint, Quaternion.identity);
                speedEnemiesSpawned++;
            }
            else if (random == 3 && heavyEnemiesSpawned < heavyEnemyCap)
            {
                Instantiate(heavyEnemyPrefab, SpawnPoint, Quaternion.identity);
                heavyEnemiesSpawned++;
            }
            else if (random == 4 && supportEnemiesSpawned < supportEnemyCap)
            {
                Instantiate(supportEnemyPrefab, SpawnPoint, Quaternion.identity);
                supportEnemiesSpawned++;
            }
            else if(random > 6 && bossCap)
            {
                Instantiate(bossPrefab, SpawnPoint, Quaternion.identity);
                bossCap = true;
            }
            else if (random == 1)
            {
                Instantiate(basicEnemyPrefab, SpawnPoint, Quaternion.identity);
            }
            float ratio = i * 1f / (number - 1);
            float timeToWait = Mathf.Lerp(minSpawnTime, maxSpawnTime, 1-ratio);
            yield return new WaitForSeconds(timeToWait);
        }
        bossCap = false;
        while (!isGameOver)
        {
            if(isDead)
            {
                Debug.Log("Died");
            }
            else if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                isGameOver = true;
                speedCycleVar = 0;

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
            isDead = true;
            StopCoroutine("SpawnEnemies");
            Debug.Log("Time Scale: 1");
            Time.timeScale = 1;

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
        if (speedCycleVar == 0)
        {
            speedCycleVar++;
            Time.timeScale = 2;
            Debug.Log("Time Scale: 2");
            if (isGameOver)
            {
                isGameOver = false;
                enemyAmountToSpawn += 5;
                // minSpawnTime += 1f;
                round++;
                roundText.text = "Round: " + round.ToString();
                StartCoroutine("SpawnEnemies", enemyAmountToSpawn);
            }
        }
        else
        {
            speedCycleVar++;
            if(speedCycleVar % 3 == 1)
            {
                Time.timeScale = 2;
                Debug.Log("Time Scale: 2");
            }
            else if (speedCycleVar % 3 == 2)
            {
                Debug.Log("Time Scale: 3");
                Time.timeScale = 3;
            }
        }

    }
}
