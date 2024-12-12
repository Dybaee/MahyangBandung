using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadScreen());
        }
    }

    IEnumerator LoadScreen()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
