using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameToMenu : MonoBehaviour
{
    public Animator anim;

    public void NewStartGameOnClicked()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        anim.SetTrigger("Press");
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
