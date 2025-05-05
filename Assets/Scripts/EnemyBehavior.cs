using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed = 1f;
    public int enemyDamagePower = 1;
    public int enemyMoneyValue = 10;
    private GameManager gameManager;
    private MoneyCounterBehavior moneyCounter;

    private Vector3[] waypoints;
    private int counter = 0;
    private const float changeDist = 0.001f;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moneyCounter = GameObject.Find("MoneyCounter").GetComponent<MoneyCounterBehavior>();
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
            moneyCounter.ChangeMoney(Random.Range(10,50));
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
