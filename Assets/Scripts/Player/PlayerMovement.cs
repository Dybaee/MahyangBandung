using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Player _player;
    private Vector3 _velocity;
    private float _gravity = -10f;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Climb();
        UpdateFlip();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        Vector3 velocity = direction * _player.Speed;
        _player.animator.SetBool("IsRunning", velocity != Vector3.zero);
        if (!controller.isGrounded)
        {
            _velocity.y += _gravity * Time.deltaTime;
        }
        else
        {
            if (_velocity.y < 0)
            {
                _velocity.y = 0; 
                if (_player.animator.GetBool("IsJumping"))
                {
                    // wait until the animation is done and then set the bool to false
                    StartCoroutine(WaitForAnimation("Jump", 0));
                }
            }
        }
        controller.Move((velocity + _velocity) * Time.deltaTime);
        

    }

    IEnumerator WaitForAnimation(string animationName, int layer)
    {
        AnimatorStateInfo stateInfo = _player.animator.GetCurrentAnimatorStateInfo(layer);
        while (stateInfo.IsName(animationName) && stateInfo.normalizedTime < 1.0f)
        {
            yield return null;
            stateInfo = _player.animator.GetCurrentAnimatorStateInfo(layer);
        }
        _player.animator.SetBool("IsJumping", false);
    }

    public GameObject torso;
    void Jump()
    {
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(_player.JumpHeight * -2f * _gravity);
            _player.animator.SetBool("IsJumping", true);
        }
    }
    void UpdateFlip()
    {
        if (isClimable)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            _player.transform.localScale = new Vector3(3, 3, -3);
        }
        else if (horizontalInput > 0)
        {
            _player.transform.localScale = new Vector3(3, 3, 3);
        }
    }

    void Climb()
    {
        if (isClimable)
        {
            //disable gravity
            _velocity.y = 0;
            _player.animator.SetBool("IsClimbing", true);
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 direction = new Vector3(0, verticalInput, 0);
            Vector3 velocity = direction * _player.ClimbSpeed;
            controller.Move(velocity * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.localScale = new Vector3(3, 3, 3);

        }
        else
        {
            _velocity.y += _gravity * Time.deltaTime;
            _player.animator.SetBool("IsClimbing", false);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public bool isClimable;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // if (hit.gameObject.CompareTag("Ladder"))
        // {
        //     Debug.Log("Ladder");
        //     isClimable = true;
        // }
        // else
        // {
        //     Debug.Log("Not Ladder");
        //     isClimable = false;
        // }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                Debug.Log("Ladder");
                isClimable = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("Not Ladder");
            isClimable = false;
        }
    }
}