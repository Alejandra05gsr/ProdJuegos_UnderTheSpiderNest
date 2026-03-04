using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class HP : MonoBehaviour
{
    public GameObject[] hpImage;
    public int playerHP = 3;
    public GameObject powerUps;
    public GameObject gameManager;

    bool isInvulnerable;

    private Animator animator;
    public GameObject fade;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < hpImage.Length; i++)
        {
            hpImage[i].SetActive(i < playerHP);
        }
    }
  
    public void TakeDamage(int damage)
    {
        if (isInvulnerable || playerHP <= 0) return;

        playerHP -= damage;

        UpdateUI();
        StartCoroutine(Invulnerable());

        if (playerHP <= 0)
        {
            playerHP = 0;
            Die();
        }

    }

    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(1f);
        isInvulnerable = false;
    }

    void Die()
    {
        //animator.SetBool("Idle", false);
        animator.SetBool("Die", true);

        if (powerUps != null)
            powerUps.SetActive(false);

        //this.GetComponent<MaterialFade>().StartFade();
        //gameManager.GetComponent<CameraShake>().ShakeCamera(2,2,2);

        Debug.Log("Jugador muere");
        Invoke(nameof(FadeGameOver), 2f);
    }

    void FadeGameOver()
    {
        fade.GetComponent<Fade>().Fading(true);
    }
}
