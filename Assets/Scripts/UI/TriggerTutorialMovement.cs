using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorialMovement : MonoBehaviour
{
    public GameObject tutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorial.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tutorial.SetActive(false);
        }
    }
}
