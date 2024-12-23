using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Animator anim;

    public void NewStartGameOnClicked()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        Time.timeScale = 1f;
        anim.SetTrigger("Press");
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
