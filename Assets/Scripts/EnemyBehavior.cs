using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 1f;
    public int enemyDamagePower = 1;
    public int enemyMoneyValue = 10;
    public int initialMoney = 10;
    private GameManager gameManager;
    private MoneyCounterBehavior moneyCounter;
    public int health;

    private Vector3[] waypoints;
    private int counter = 0;
    private const float changeDist = 0.001f;

    public float bonusPerRound = 25f;

    private AudioSource source;
    public AudioClip deathSFX;

    public void updateMoney(int round)
    {
        enemyMoneyValue += (int) (bonusPerRound * round);
        Debug.Log("MONEY CHANGED: " + enemyMoneyValue);
    }

    private void Start()
    {
        source = GameObject.Find("Audio").GetComponent<AudioSource>();
        initialMoney = enemyMoneyValue;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moneyCounter = GameObject.Find("MoneyCounterText").GetComponent<MoneyCounterBehavior>();
        waypoints = gameManager.waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == waypoints.Length)
        {
            gameManager.EnemyHasReachedTheFortress(enemyDamagePower);
            Destroy(gameObject);
            return;
        }
        else
        {
            float dist = Vector3.Distance(transform.position, waypoints[counter]);
            if (dist < changeDist)
            {
                counter++;
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, waypoints[counter], step);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            if (health - other.GetComponent<BulletBehavior>().damage <= 0)
            {
                moneyCounter.ChangeMoney(Random.Range(enemyMoneyValue, enemyMoneyValue + 50));
                source.PlayOneShot(deathSFX);
                Destroy(gameObject);
            }
            health -= other.GetComponent<BulletBehavior>().damage;
            Destroy(other.gameObject);
        }
    }

}
