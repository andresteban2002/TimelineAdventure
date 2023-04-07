using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaraonLife : MonoBehaviour
{
    private const string FARAON_DEATH = "Faraon_Death";

    private Animator _animator;
    [SerializeField] int life;
    public bool isDeath;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        _animator.Play(FARAON_DEATH);
    }
    
    public void death()
    { 
        if (isDeath)
        {
            Destroy(gameObject);
        }
    }
}
