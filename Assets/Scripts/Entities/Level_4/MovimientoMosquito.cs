using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class MovimientoMosquito : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer _spriteRenderer;
    private const string MOSQUITO_WALK = "Mosquito_Walk";
    private const string MOSQUITO_ATTACK = "Mosquito_Attack";
    private Animator _animator;
    private string currentStep;
    private string direction = "right";
    public AudioSource attack;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        changeAnimationState(MOSQUITO_WALK);
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
        if(currentStep==newState) return;
        _animator.Play(newState);
        currentStep = newState;
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

        if (other.CompareTag("Player") && !GetComponent<Life_Mosquito>().isDeath)
        {
            changeAnimationState(MOSQUITO_ATTACK);
        }
    }

    private void startAttack()
    {
        player.GetComponent<PlayerLife>().nextDamageTime = 0;
        player.GetComponent<PlayerLife>().getNaturalDamage(15);
        attack.Play();
    }

    private void stopAttack()
    {
        changeAnimationState(MOSQUITO_WALK);
    }
}