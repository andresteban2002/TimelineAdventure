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
    //private const string CAVEMAN_ATTACK = "cavemanAttack";
    private Animator _animator;
    Animator _animatorHarry;
    private const string HARRY_DAMAGE = "Harry_Damage";
    private string currentStep;

    private string direction = "right";
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

        /*if (!isAttack)
        { 
            changeAnimationState(CAVEMAN_WALK);
        }
        else
        {
            attackTime -= Time.deltaTime;
            if (attackTime < 0.6)
            {
                _animator.StopPlayback();
                isAttack = false;
            }
        }*/
    }
    
    public void changeAnimationState(string newState)
    {
        if(currentStep==newState) return;
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

        //if (other.CompareTag("Player"))
        //{
            //changeAnimationState(MOSQUITO_ATTACK);
            //_animatorHarry = other.GetComponent<Animator>();
            //_animatorHarry.Play(HARRY_DAMAGE);
            //other.GetComponent<PlayerLife>().getNaturalDamage(15);
            //isAttack = true;
        //}
        
    }

    private void stopAttack()
    {
        changeAnimationState(MOSQUITO_WALK);
    }
}
