using UnityEngine;

public class CavemanLife : MonoBehaviour
{
    private const string CAVEMAN_DEATH = "Caveman_Death";
    private Animator _animator;
    [SerializeField] int life;
    public bool isDeath;

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
}

