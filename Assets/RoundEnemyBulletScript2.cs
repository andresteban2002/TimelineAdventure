using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEnemyBulletScript2 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Vector3 direction = new Vector3(player.transform.position.x + 10f, player.transform.position.y, 0) - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerLife>().getNaturalDamage(20);
            Destroy(gameObject);
        }
    }
}
