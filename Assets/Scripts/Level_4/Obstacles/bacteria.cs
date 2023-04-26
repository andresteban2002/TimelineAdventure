using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bacteria : MonoBehaviour
{
   
    [SerializeField] private float damageTime;
    private float nextDamageTime;
    
    
    //Animaciones
    Animator _animator;
    Animator _animatorHarry;
    private const string BACTERIA_ANIMATION = "bacteria_animation";
    private const string HARRY_DAMAGE = "Harry_Damage";
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        _animator.Play(BACTERIA_ANIMATION);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animatorHarry = other.GetComponent<Animator>();
            nextDamageTime -= Time.deltaTime;
            if (nextDamageTime < 0.6)
            {
                Debug.Log(nextDamageTime);
                _animatorHarry.StopPlayback();
                other.GetComponent<HarryMovement>().canMove = true;
            }

            if (nextDamageTime <= 0)
            {
                _animatorHarry.Play(HARRY_DAMAGE);
                //other.GetComponent<HarryMovement>().canMove = false;
                other.GetComponent<PlayerLife>().getNaturalDamage(5);
                nextDamageTime = damageTime;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _animatorHarry = other.GetComponent<Animator>();
            nextDamageTime -= Time.deltaTime;
            if (nextDamageTime < 0.6)
            {
                other.GetComponent<HarryMovement>().canMove = true;
            }

            _animatorHarry.Play(HARRY_DAMAGE);
            //other.GetComponent<HarryMovement>().canMove = false;
            other.GetComponent<PlayerLife>().getNaturalDamage(10);
            nextDamageTime = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HarryMovement>().canMove = true;
        }
    }
}

