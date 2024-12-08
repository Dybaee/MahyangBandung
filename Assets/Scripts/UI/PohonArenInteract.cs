using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PohonArenInteract : MonoBehaviour
{
    public GameObject dialogSystem;
    public GameObject eInteract; 

    public MonoBehaviour playerMovementScript;
    public MonoBehaviour dialogueScript;
    private bool InRange;

    private void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.E))
        {
            if (dialogSystem != null)
            {
                bool dialogActive = !dialogSystem.activeSelf;
                dialogSystem.SetActive(dialogActive);
                dialogueScript.enabled = dialogActive; // Enable dialogue script only when dialog is active
                playerMovementScript.enabled = !dialogActive; // Disable player movement when dialog is active

                // Set eInteract to inactive after interaction
                if (eInteract != null)
                {
                    Destroy(eInteract);
                }
            }
            else
            {
                Debug.LogWarning("Dialog System is not assigned!");
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
            Debug.Log("Player entered range.");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
            Debug.Log("Player exited range.");
            if (dialogSystem != null && dialogSystem.activeSelf)
            {
                dialogSystem.SetActive(false);
                playerMovementScript.enabled = true;
                dialogueScript.enabled = false;
            }
        }
    }
}