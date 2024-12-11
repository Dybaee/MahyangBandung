using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{

    private bool _isPlayerInTrap = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isPlayerInTrap)
        {
            _isPlayerInTrap = true;
            other.gameObject.GetComponent<Player>().TakeDamage(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _isPlayerInTrap)
        {
            _isPlayerInTrap = false;
        }
    }
}
