using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;


public class CavemanMovement : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer _spriteRenderer;
    private const string CAVEMAN_WALK = "Caveman_Walk";
    private Animator _animator;
    private string currentStep;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            if (player.transform.position.x > transform.position.x)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }
        }
        //changeAnimationState(CAVEMAN_WALK);
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




}
