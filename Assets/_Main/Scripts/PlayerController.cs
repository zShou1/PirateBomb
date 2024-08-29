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
    private bool _isJumpPressed;
    private bool _isGrounded;
    public float _jumpHeight;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _direction.x = Input.GetAxisRaw(Constants.InputX);
        _isJumpPressed = Input.GetKeyDown(KeyCode.Space);
    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_direction.x * _moveSpeed, _rb.velocity.y);
        Jump();
//        _isGrounded = Mathf.Abs(_rb.velocity.y) < 0.1f;
        Flip();
    }

    private void Anim()
    {
        if (_isGrounded)
        {
            if (_direction.x != 0)
            {
                _animator.Play("Run");
            }
            else
            {
                _animator.Play("Idle");
            }
        }
        
        if(_isJumpPressed)
        {
            _animator.Play("Jump");
        }        
    }

    private void Jump()
    {
        if (_isJumpPressed)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
        }
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
