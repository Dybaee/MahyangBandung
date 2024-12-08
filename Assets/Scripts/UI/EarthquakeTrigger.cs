using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject earthquakeCamera;
    public GameObject earthquakeTrigger;
    public EarthquakeDialog earthquakeDialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EarthquakeCam());
        }
    }

    private IEnumerator EarthquakeCam()
    {
        earthquakeCamera.SetActive(true);
        anim.SetBool("IsEarthquake", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("IsEarthquake", false);
        earthquakeCamera.SetActive(false);

        earthquakeDialog.enabled = true; 
        earthquakeDialog.ShowDialog(); 

        Destroy(earthquakeTrigger, 10f);
    }
}
