using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffingTrigger : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.getComponent<EnemyBehavior>().health += 2;
            other.getComponent<EnemyBehavior>().enemyDamagePower += 5;
            other.getComponent<EnemyBehavior>().speed += 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.getComponent<EnemyBehavior>().health -= 2;
            other.getComponent<EnemyBehavior>().enemyDamagePower -= 5;
            other.getComponent<EnemyBehavior>().speed -= 2;
        }
    }
}
