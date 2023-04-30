using UnityEngine;

public class CavewomanLife : MonoBehaviour
{
    private const string CAVEWOMAN_DAMAGE = "Cavewoman_Damage";
    private const string CAVEWOMAN_DEATH = "Cavewoman_Death";
    private const string CAVEWOMAN_WALK = "Cavewoman_Walk";
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
        _animator.Play(CAVEWOMAN_DAMAGE);
        if (life <= 0)
        {
            isDeath = true;
            animationdeath();
        }

    }
    public void animationdeath()
    { 
        _animator.Play(CAVEWOMAN_DEATH);
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
        _animator.Play(CAVEWOMAN_WALK);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDeath)
        {
            if (other.CompareTag("Boomerang"))
            {
                getNaturalDamage(20);
                damage.Play();
            }
        }
    }
}

