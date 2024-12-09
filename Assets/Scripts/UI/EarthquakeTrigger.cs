using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeTrigger : MonoBehaviour
{
    public Animator anim;
    public GameObject earthquakeCamera;
    public GameObject earthquakeTrigger;
    public EarthquakeDialog earthquakeDialog;
    public Player playerScript;
    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EarthquakeCam());
        }
    }

    private IEnumerator EarthquakeCam()
    {
        playerMovement.enabled = false;
        playerScript.enabled = false;
        earthquakeCamera.SetActive(true);
        anim.SetBool("IsEarthquake", true);
        yield return new WaitForSeconds(2f);
        anim.SetBool("IsEarthquake", false);
        earthquakeCamera.SetActive(false);

        earthquakeDialog.enabled = true; 
        earthquakeDialog.ShowDialog();
        playerMovement.enabled = true;
        playerScript.enabled = true;


        Destroy(earthquakeTrigger, 10f);
    }
}
