using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 Direction;
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, 360*speed*Time.deltaTime);
    }

    private void FixedUpdate()    {
        _rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
}
