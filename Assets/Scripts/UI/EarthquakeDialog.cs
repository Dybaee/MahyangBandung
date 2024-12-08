using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeDialog : MonoBehaviour
{
    public GameObject dialogSystem;
    public PlayerMovement playerMovementScript;
    public MonoBehaviour dialogueScript;
    private bool InRange;

    private void Update()
    {
        if (InRange && Input.GetKeyDown(KeyCode.E)) 
        {
            ToggleDialog();
        }
    }

    private void ToggleDialog()
    {
        if (dialogSystem != null)
        {
            bool dialogActive = !dialogSystem.activeSelf;
            dialogSystem.SetActive(dialogActive);
            dialogueScript.enabled = dialogActive;
            playerMovementScript.enabled = !dialogActive; 

            Debug.Log(dialogActive ? "Dialog opened." : "Dialog closed.");
        }
        else
        {
            Debug.LogWarning("Dialog System is not assigned!");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            InRange = false;
            if (dialogSystem != null && dialogSystem.activeSelf)
            {
                dialogSystem.SetActive(false);
                playerMovementScript.enabled = true;
                dialogueScript.enabled = false;
            }
        }
    }

    public void ShowDialog()
    {
        dialogSystem.SetActive(true);
    }
}