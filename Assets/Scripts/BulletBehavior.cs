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
}
