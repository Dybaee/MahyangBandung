using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using DG.Tweening;
// using Cinemachine;
using UnityEngine.SceneManagement;
// using UnityEngine.TestTools.Constraints;

public class PlayerHealthSystem : MonoBehaviour
{
    private bool isInvicible = false;
    private int maxHealth = 3;
    [SerializeField] int currentHealth;
    [SerializeField] CheckpointSystem checkPointSystem;
    // [SerializeField] CinemachineVirtualCamera cinemachineCamera;
    public Image[] healthImage;
    public Sprite lostLifeSprite;
    Collider2D playerCollider;
    SpriteRenderer playerSprite;




    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
        currentHealth = maxHealth;
        Player player = FindObjectOfType<Player>();
        player.OnTakeDamage += TakeDamage;
    }

    public void TakeDamage()
    {
        if (currentHealth > 1 && !isInvicible)
        {
            // isInvicible = true;
            // playerSprite.DOColor(Color.red, 0.5f).SetLoops(3, LoopType.Yoyo).onStepComplete = () =>
            // {
            //     playerSprite.color = Color.white;
            //     isInvicible = false;
            // };
            healthImage[currentHealth - 1].sprite = lostLifeSprite;
            currentHealth--;
            Debug.Log("Damage Taken | CurrentHealth :  " + currentHealth);
            // transform.position = checkPointSystem.currentCheckpoint.position;
        }
        else
        {
            healthImage[currentHealth - 1].sprite = lostLifeSprite;
            Died();
        }
    }

    void Died()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
