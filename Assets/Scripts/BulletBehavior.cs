using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 direction;
    public int damage = 5;
    private AudioSource source;
    public AudioClip laser;
    public GameObject rayBullet;
    public GameObject sparkBullet;
    public GameObject moonBullet;

    private void Start()
    {
        source = GameObject.Find("Audio").GetComponent<AudioSource>();
        source.PlayOneShot(laser);
        direction = direction.normalized;
        float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Destroy(gameObject, 10);
    }
    private void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void SetBulletDamage(int damage)
    {
        if(this.gameObject.name == "MoonBullet(Clone)")
        {
            moonBullet.GetComponent<BulletBehavior>().damage = damage;
        }
        else if (this.gameObject.name == "SparkBullet(Clone)")
        {
            sparkBullet.GetComponent<BulletBehavior>().damage = damage;
        }
        else if (this.gameObject.name == "RayBullet(Clone)")
        {
            rayBullet.GetComponent<BulletBehavior>().damage = damage;
        }
    }

    public void SetBulletSpeed(int speed)
    {
        if (this.gameObject.name == "MoonBullet(Clone)")
        {
            moonBullet.GetComponent<BulletBehavior>().speed = speed;
        }
        else if (this.gameObject.name == "SparkBullet(Clone)")
        {
            sparkBullet.GetComponent<BulletBehavior>().speed = speed;
        }
        else if (this.gameObject.name == "RayBullet(Clone)")
        {
            rayBullet.GetComponent<BulletBehavior>().speed = speed;
        }
    }
}
