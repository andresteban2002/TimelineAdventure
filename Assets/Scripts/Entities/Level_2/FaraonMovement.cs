using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class FaraonMovement : MonoBehaviour
{
     private SpriteRenderer _spriteRenderer;
     private Animator _animator;
     Animator _animatorHarry;
     public GameObject player;
     
     private string currentStep;
     private string direction = "right";
     private const string FARAON_WALK = "Faraon_quiet";
     private const string FARAON_ATTACK = "Faraon_Attack";
     private const string HARRY_DAMAGE = "Harry_Damage";
     // Start is called before the first frame update
    void Start()
    {
		_spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        changeAnimationState(FARAON_WALK);
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == "right")
        {
            transform.Translate(Vector3.right * Time.deltaTime * 4.0f); 
        }
        else if (direction == "left")
        {
            transform.Translate(Vector3.left * Time.deltaTime * 4.0f);
        }
    }

    public void changeAnimationState(string newState)
    {
        if (currentStep==newState) return;
        _animator.Play(newState);
        currentStep = newState;
    }

     private void FixedUpdate()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemyLimit"))
        {
            if (direction == "right")
            {
                _spriteRenderer.flipX = true;
                direction = "left";
            }
            else if (direction == "left")
            {
                _spriteRenderer.flipX = false;
                direction = "right";
            }
        }

        if (other.CompareTag("Player"))
        {
            changeAnimationState(FARAON_ATTACK);
            _animatorHarry = other.GetComponent<Animator>();
            _animatorHarry.Play(HARRY_DAMAGE);
            other.GetComponent<PlayerLife>().getNaturalDamage(15);
            //isAttack = true;
        }
        
    }
    
    private void stopAttack()
    {
        changeAnimationState(FARAON_WALK);
    }
}
