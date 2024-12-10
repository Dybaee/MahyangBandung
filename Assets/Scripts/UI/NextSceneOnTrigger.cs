using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneOnTrigger : MonoBehaviour
{

    

    private void Start()
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
        SceneManager.LoadSceneAsync("Stage1");
    }
}
