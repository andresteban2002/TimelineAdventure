using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartianScript : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    private GameObject player;

    public float distanceToStop = 5f;
    public float topLimit = 55;
    public float bottomLimit = 30;
    public float speed = 3f;

    public float shootSpeed;
    private float timer; 
    public GameObject bullet;
    public GameObject round_bullet;
    public GameObject round_bullet2;
    public GameObject round_bullet3;
    public GameObject round_bullet4;
    public Transform bulletPos;
    public Transform bullet2Pos;
    public Transform roundBullet1Pos;
    public Transform roundBullet2Pos;
    public Transform roundBullet3Pos;
    public Transform roundBullet4Pos;

    private bool shooting_first_bullet = true;
    private bool shooting_second_bullet = true;    

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {        
        Vector3 scale = transform.localScale;

        if (target.transform.position.x > transform.position.x) {
            scale.x = Mathf.Abs(scale.x);
            transform.Translate(x: speed * Time.deltaTime, y:0, z:0);
        } else {
            scale.x = Mathf.Abs(scale.x) * -1;
            transform.Translate(x: speed * Time.deltaTime * -1, y:0, z:0);
        }

        transform.localScale = scale;

        if (player != null)
        {
            Attack();
        }
    }

    void Attack()
    {
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > 5)
        {
            timer += Time.deltaTime;
            if (Mathf.Round(timer) == 2 & shooting_first_bullet)
            {
                if (bullet != null)
                {
                    Instantiate(bullet, bullet2Pos.position, Quaternion.identity);
                    shooting_first_bullet = false;
                }                
            }

            if (Mathf.Round(timer) > 2 & shooting_second_bullet)
            {
                if (bullet != null)
                {
                    Instantiate(bullet, bulletPos.position, Quaternion.identity);                    

                    shooting_second_bullet = false;
                }                
            }

            if (Mathf.Round(timer) > 4)
            {
                if (bullet != null)
                {
                    Instantiate(round_bullet, roundBullet1Pos.position, Quaternion.identity);
                    Instantiate(round_bullet2, roundBullet2Pos.position, Quaternion.identity);
                    Instantiate(round_bullet3, roundBullet3Pos.position, Quaternion.identity);
                    Instantiate(round_bullet4, roundBullet4Pos.position, Quaternion.identity);
                    
                    shooting_first_bullet = true;
                    shooting_second_bullet = true;
                    timer = 0;
                }                
            }
        }
    }


    private void FixedUpdate() {
        if (target != null) {
            if (transform.position.y > topLimit) {
                rb.velocity = -transform.up * speed;
            } else if (transform.position.y < bottomLimit) {
                rb.velocity = transform.up * speed;
            } else {
                if (Vector2.Distance(target.position, transform.position) < distanceToStop){
                    rb.velocity = transform.up * speed;
                } else if (Vector2.Distance(target.position, transform.position) > distanceToStop){
                    rb.velocity = -transform.up * speed;
                } else {
                    rb.velocity = Vector2.zero;
                }
            }
        }
    }

}
