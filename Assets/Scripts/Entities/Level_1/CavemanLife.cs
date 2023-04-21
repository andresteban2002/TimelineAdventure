using UnityEngine;

public class CavemanLife : MonoBehaviour
{
    private const string CAVEMAN_DAMAGE = "Caveman_Damage";
    private const string CAVEMAN_DEATH = "Caveman_Death";
    private const string CAVEMAN_WALK = "Caveman_Walk";
    private Animator _animator;
    [SerializeField] int life;
    public bool isDeath;
    public AudioSource damage;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
       
    }

    public void getNaturalDamage(int damage)
    {
        life -= damage;
        _animator.Play(CAVEMAN_DAMAGE);
        if (life <= 0)
        {
            isDeath = true;
            animationdeath();
        }

    }
    public void animationdeath()
    { 
        _animator.Play(CAVEMAN_DEATH);
    }
    public void death()
    { 
        if (isDeath)
        {
            Destroy(gameObject);
        }
    }
    
    public void StopDamage()
    {
        _animator.Play(CAVEMAN_WALK);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDeath)
        {
            if (other.CompareTag("Boomerang"))
            {
                getNaturalDamage(15);
                damage.Play();
            }
        }
    }
}

