using System;
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
    private bool isDialogActive = false;

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
        if (Input.GetButtonDown("Fire1") && !isDialogActive)
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
        GameObject pro = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
        pro.GetComponent<Projectile>().targetType = TargetType.Enemy;

    }

    public Action OnTakeDamage;

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("GetHit");  
        health -= damage;
        OnTakeDamage?.Invoke();
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void SetDialogActive(bool isActive)
    {
        isDialogActive = isActive;
    }
}
