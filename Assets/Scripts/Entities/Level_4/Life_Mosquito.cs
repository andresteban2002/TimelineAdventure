using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Mosquito : MonoBehaviour
{
    private const string MOSQUITO_DAMAGE = "Mosquito_Damage";
    private const string MOSQUITO_DEATH = "Mosquito_Death";
    private const string MOSQUITO_WALK = "Mosquito_Walk";
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
        _animator.Play(MOSQUITO_DAMAGE);
        if (life <= 0)
        {
            isDeath = true;
            animationdeath();
        }

    }
    public void animationdeath()
    { 
        _animator.Play(MOSQUITO_DEATH);
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
        _animator.Play(MOSQUITO_WALK);
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

