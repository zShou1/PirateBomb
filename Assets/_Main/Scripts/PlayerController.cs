using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector3 _direction;
    private float _moveSpeed = 3f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxisRaw(Constants.InputX);
        _rb.velocity = _direction * _moveSpeed;
        if (_direction.x != 0)
        {
            _animator.Play("Run");
        }
        else
        {
            _animator.Play("Idle");
        }
        Flip();
    }

    private void Flip()
    {
        if (_direction.x > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }

        if (_direction.x < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }
}
