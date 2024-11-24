using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Player _player;
    private Vector3 _velocity;
    private float _gravity = -9.8f;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        UpdateFlip();
        Debug.Log(_controller.isGrounded);
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _player.Speed;
        _player.animator.SetBool("IsRunning", velocity != Vector3.zero);
        if (!_controller.isGrounded)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }

        _controller.Move((velocity + _velocity) * Time.deltaTime);

    }

    void Jump()
    {
        if (_controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(_player.JumpHeight * -2f * _gravity);
            _player.animator.SetTrigger("Jump");
        }
    }

    void UpdateFlip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            _player.transform.localScale = new Vector3(3,3,3);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            _player.transform.localScale = new Vector3(3,3,-3);
        }
    }
}
