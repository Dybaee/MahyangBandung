using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    [SerializeField] 
    private PlayerMovement _playerMovement;

    [Header("Player Stats")]

    [SerializeField]
    private int speed;
    [SerializeField]
    private int health;

    [SerializeField]
    private int jumpHeight;
    public int Speed
    {
        get => speed;
        set => speed = value;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

    public int JumpHeight
    {
        get => jumpHeight;
        set => jumpHeight = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
