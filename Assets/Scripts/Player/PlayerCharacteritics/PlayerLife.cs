using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int life;
    [SerializeField] int maxLife;
    [SerializeField] private LifeBar lifebar;
    private HarryMovement movementPlayer;
    private Rigidbody2D _rigidbody2D;
    public bool isDeath;
    private float deathEnd = 0;
    
    //Animaciones
    Animator animator;
    private const string HARRY_DEATH = "Harry_Death";
    //[SerializeField] private float timeLostControl;
    void Start()
    {
        life = maxLife;
        movementPlayer = GetComponent<HarryMovement>();
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        lifebar.StartLifeBar(life);
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
                Destroy(gameObject);
            }
        }
    }

    public void getNaturalDamage(int damage)
    {
        life -= damage;
        lifebar.ChangeCurrentLife(life);
        if (life <= 0)
        {
            isDeath = true;
        }
        

        /*StartCoroutine(lostControl());
        movementPlayer.rebound(position);*/
    }

    public void health(int healthy)
    {
        if ((life + healthy) > maxLife)
        {
            life = maxLife;
        }
        else
        {
            life += maxLife;
        }

    }

    /*public IEnumerator lostControl()
    {
        movementPlayer.canMove = false;
        yield return new WaitForSeconds(timeLostControl);
        movementPlayer.canMove = true;
    }*/
}
