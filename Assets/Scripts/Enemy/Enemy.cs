using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField]
    private int _health;
    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _attackRange;
    [SerializeField]

    private float _moveSpeed;
    [SerializeField]
    private float _chaseRange;
    private Animator _animator;
    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public int Damage
    {
        get => _damage;
        set => _damage = value;
    }
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {

        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            Vector3 direction = player.transform.position - transform.position;
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1.37f, 1.37f, -1.37f);
            }
            else
            {
                transform.localScale = new Vector3(1.37f, 1.37f, 1.37f);
            }

            if (distance < _chaseRange)
            {
                Debug.Log("Chasing player");
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _moveSpeed * Time.deltaTime);
                if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "IsWalking")
                {
                    //interupt other animation
                    _animator.SetBool("IsWalking", true);
                }
                //check if move forward or not
                _animator.SetBool("IsWalking", true);
                //check direction
            }
            else
            {
                _animator.SetBool("IsWalking", false);
            }
        }
    }


    IEnumerator Attack()
    {
        while (true)
        {
            if (player != null)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance < _attackRange)
                {
                    if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack")
                    {
                        _animator.SetTrigger("Attack");
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void DealDamage()
    {
        if (player != null)
        {
            player.GetComponent<Player>().TakeDamage(_damage);
        }
    }

    public void Shoot()
    {
        Transform spawnPoint = transform.Find("SpawnPoint");
        GameObject bullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Projectile>().targetType = TargetType.Player;
        bullet.GetComponent<Projectile>().Target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}