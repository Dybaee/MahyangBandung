using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

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

    private VisualEffect _vfx;
    public TargetType targetType;

    private bool _isLeft;
    // Start is called before the first frame update
    void Start()
    {
        _vfx = GetComponentInChildren<VisualEffect>();
        if (_vfx != null)
        {
            _vfx.Play();
        }

        if (_target.position.x < transform.position.x)
        {
            _isLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            _isLeft = false;
            transform.localScale = new Vector3(1, 1, 1);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        //Move forward to target

        if (_isLeft)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
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