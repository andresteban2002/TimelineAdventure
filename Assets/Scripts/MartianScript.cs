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
    public GameObject hard_round_bullet;
    public Transform bulletPos;
    public Transform bullet2Pos;
    public Transform roundBullet1Pos;
    public Transform roundBullet2Pos;
    public Transform roundBullet3Pos;
    public Transform roundBullet4Pos;
    public Transform hardRoundBulletPos;

    public AudioSource sbullet;
    public AudioSource sround_bullet;
    public AudioSource shard_round_bullet;
    public AudioSource explosion;

    private bool shooting_first_bullet = true;
    private bool shooting_second_bullet = true;   
    private bool shooting_third_bullet = true;   
    private Animator anim;
     
    private int harryHealth;

    public static bool is_rage = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if (is_rage)
        {
            transform.position = new Vector3(416, 45, 0);
            player.transform.position = new Vector3(387, 19, 0);
        }
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameObject != null)
        {
            harryHealth = player.GetComponent<PlayerLife>().getCurrentLife();

            if (harryHealth > 0)
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
                    if (transform.position.x >= 682)
                    {
                        explosion.Play();
                        anim.Play("explosion"); 
                        if (transform.position.x >= 692)
                        {                       
                            Destroy(gameObject);
                        }
                    }
                    Attack();
                }
            }
            else
            {
                if (!is_rage)
                {
                    ItemCollectorLv5.combustibles = 0;
                }
            }
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
                    sbullet.Play();
                }                
            }

            if (Mathf.Round(timer) > 2 & shooting_second_bullet)
            {
                if (bullet != null)
                {
                    Instantiate(bullet, bulletPos.position, Quaternion.identity);
                    shooting_second_bullet = false;
                    sbullet.Play();
                }                
            }

            if (Mathf.Round(timer) > 3 & shooting_third_bullet)
            {
                if (bullet != null)
                {
                    Instantiate(round_bullet, roundBullet1Pos.position, Quaternion.identity);
                    Instantiate(round_bullet2, roundBullet2Pos.position, Quaternion.identity);
                    Instantiate(round_bullet3, roundBullet3Pos.position, Quaternion.identity);
                    Instantiate(round_bullet4, roundBullet4Pos.position, Quaternion.identity);                    
                    shooting_third_bullet = false;
                    sround_bullet.Play();
                }                
            }

            if (Mathf.Round(timer) > 4)
            {
                if (transform.position.x >= 400)
                {
                    if (bullet != null)
                    {
                        Instantiate(hard_round_bullet, hardRoundBulletPos.position, Quaternion.identity);
                        
                        shooting_first_bullet = true;
                        shooting_second_bullet = true;
                        shooting_third_bullet = true;
                        timer = 0;

                        shard_round_bullet.Play();
                    }                
                }
                shooting_first_bullet = true;
                shooting_second_bullet = true;
                shooting_third_bullet = true;
                timer = 0;
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
