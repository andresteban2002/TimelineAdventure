using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife instance;
    public int life;
    [SerializeField] int maxLife;
    [SerializeField] private LifeBar lifebar;
    [SerializeField] private GameObject gameover;
    private HarryMovement movementPlayer;
    private Rigidbody2D _rigidbody2D;
    public bool isDeath;
    private float deathEnd = 0;
    public float nextDamageTime;
    private LogicalBright _brightController;
    private LogicalVolume _volumeController;
    
    //Animaciones
    Animator animator;
    private const string HARRY_DEATH = "Harry_Death";
    private const string HARRY_DAMAGE = "Harry_Damage";
    //[SerializeField] private float timeLostControl;
    
    public AudioSource getFruit;
    public AudioSource death;
    void Start()
    {
        gameover.SetActive(false);
        movementPlayer = GetComponent<HarryMovement>();
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        lifebar.StartLifeBar(100);
        // life = NicknameScript.instance.data.matches[NicknameScript.instance.actMatch].life;
        lifebar.ChangeCurrentLife(life);
    }

    private void Update()
    {
        if (isDeath)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            movementPlayer.canMove = false;
            animator.Play(HARRY_DEATH);
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
            transform.Translate(Vector3.up * 3f * Time.deltaTime);
            deathEnd += Time.deltaTime;
            if (deathEnd >= 2)
            {
                gameObject.SetActive(false);
            }
        }
        nextDamageTime -= Time.deltaTime;
        if (nextDamageTime < 0.6 && !isDeath)
        {
            GetComponent<HarryMovement>().canMove = true;
            animator.StopPlayback();
        }
    }

    public void getNaturalDamage(int damage)
    {
        life -= damage;
        lifebar.ChangeCurrentLife(life);
        animator.Play(HARRY_DAMAGE);
        GetComponent<HarryMovement>().canMove = false;
        if (life <= 0)
        {
            death.Play();
            isDeath = true;
        }
        
    }

    public void health(int healthy)
    {
        if ((life + healthy) > maxLife)
        {
            life = maxLife;
        }
        else
        {
            life += healthy;
        }
        lifebar.ChangeCurrentLife(life);
    }
    
    private void Awake()
    {
        _brightController = FindObjectOfType<LogicalBright>();
        _volumeController = FindObjectOfType<LogicalVolume>();
        instance = this;
    }

    private void showMenuGameOver()
    {
        gameover.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "fruit")
        {
            health(15);
            getFruit.Play();
            Destroy(col.gameObject);
        }
    }
}
