using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject player;

    [SerializeField] float lifeTime;
    [SerializeField] float speed;

    void Update() => BulletMove();

    void BulletMove()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0) Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

    }
}
