using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInteract : MonoBehaviour
{

    public GameObject eInteract;

    // Start is called before the first frame update
    void Start()
    {
        eInteract.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        eInteract.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        eInteract.SetActive(false);
    }
}
