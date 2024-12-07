using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _damage;
    [SerializeField]

    private Transform _target;
    public Transform Target
    {
        get => _target;
        set => _target = value;
    }

    public TargetType targetType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move forward to target
        if (_target != null)
        {
            //Move projectile left or right depending on the target position
            if (_target.position.x < transform.position.x)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }



    }

    void OnCollisionEnter(Collision other)
    {
        switch (targetType)
        {
            case TargetType.Player:
                if (other.gameObject.CompareTag("Player"))
                {
                    other.gameObject.GetComponent<Player>().TakeDamage((int)_damage);
                    Destroy(gameObject);
                }
                break;
            case TargetType.Enemy:
                if (other.gameObject.CompareTag("Enemy"))
                {
                    other.gameObject.GetComponent<Enemy>().TakeDamage((int)_damage);
                    Destroy(gameObject);
                }
                break;
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}

public enum TargetType
{
    Player,
    Enemy
}