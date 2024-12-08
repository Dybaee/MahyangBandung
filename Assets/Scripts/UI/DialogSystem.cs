using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogSystem : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialogBox;
    public string[] lines;
    public float textSpeed;
    private bool canNextLine;
    private int index;
    public Player playerScript;
    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(true);
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canNextLine)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                canNextLine = true;
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        playerMovement.enabled = false;
        playerScript.enabled = false;
        canNextLine = false;
        textComponent.text = string.Empty;

        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        canNextLine = true;
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialog();
        }
    }

    void EndDialog()
    {
        playerScript.SetDialogActive(false);
        gameObject.SetActive(false);
        dialogBox.SetActive(false);
        playerMovement.enabled = true;
        playerScript.enabled = true;
    }
}
