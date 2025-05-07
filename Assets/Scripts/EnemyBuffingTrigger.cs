using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffingTrigger : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello");
        if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBehavior>().health += 2;
            other.gameObject.GetComponent<EnemyBehavior>().enemyDamagePower += 5;
            other.gameObject.GetComponent<EnemyBehavior>().speed += 2;
            gameObject.GetComponentInParent<EnemyBehavior>().health += 2;
            gameObject.GetComponentInParent<EnemyBehavior>().enemyDamagePower += 5;
            gameObject.GetComponentInParent<EnemyBehavior>().speed += 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyBehavior>().health -= 2;
            other.gameObject.GetComponent<EnemyBehavior>().enemyDamagePower -= 5;
            other.gameObject.GetComponent<EnemyBehavior>().speed -= 2;
            gameObject.GetComponentInParent<EnemyBehavior>().health -= 2;
            gameObject.GetComponentInParent<EnemyBehavior>().enemyDamagePower -= 5;
            gameObject.GetComponentInParent<EnemyBehavior>().speed -= 2;
        }
    }
}
