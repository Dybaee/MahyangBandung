using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private float _moveSpeed;
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
        GameObject player = getNearestPlayer();
        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance > _attackRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, _moveSpeed * Time.deltaTime);
                _animator.SetBool("IsWalking", true);
            }
            else
            {
                _animator.SetBool("IsWalking", false);
            }
        }
    }

    GameObject getNearestPlayer()
    {
        Debug.Log("Finding player");    
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject nearestPlayer = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPlayer = player;
            }
        }
        return nearestPlayer;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            GameObject player = getNearestPlayer();
            if (player != null)
            {
                Debug.Log("Player found");
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
        GameObject player = getNearestPlayer();
        if (player != null)
        {
            player.GetComponent<Player>().TakeDamage(_damage);
        }
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
