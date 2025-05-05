using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletBehavior : BulletBehavior
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {

        }
    }
}
