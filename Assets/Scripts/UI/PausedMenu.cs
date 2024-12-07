using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class PausedMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    private bool isPaused = false;
    public PlayerMovement playerScript;
    public Button resumeButton;
    public Button exitButton;

    void Start()
    {
        Button btn = resumeButton.GetComponent<Button>();
        btn.onClick.AddListener(ResumeButtonOnClick);

        Button btn2 = exitButton.GetComponent<Button>();
        btn2.onClick.AddListener(ExitGame);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        playerScript.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        playerScript.enabled = true;
        isPaused = false;
    }

    public void ResumeButtonOnClick()
    {
        Time.timeScale = 1f;
        playerScript.enabled = true;
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenuCanvas.SetActive(false);
        playerScript.enabled = false;
    }
}
