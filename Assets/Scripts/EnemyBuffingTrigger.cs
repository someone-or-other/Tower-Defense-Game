using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffingTrigger : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello");
        if(other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyBehavior>().health += 1;
            other.gameObject.GetComponent<EnemyBehavior>().enemyDamagePower += 5;
            other.gameObject.GetComponent<EnemyBehavior>().speed += 1;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyBehavior>().health -= 1;
            other.gameObject.GetComponent<EnemyBehavior>().enemyDamagePower -= 5;
            other.gameObject.GetComponent<EnemyBehavior>().speed -= 1;
        }
    }
}
