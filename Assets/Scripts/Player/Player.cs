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
    [SerializeField]
    private int attackDamage { get; set; }

    [SerializeField]
    private GameObject projectile;
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
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }


    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public void SpawnProjectile()
    {
        Transform projectileSpawn = transform.Find("spawnPoint");
        Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
