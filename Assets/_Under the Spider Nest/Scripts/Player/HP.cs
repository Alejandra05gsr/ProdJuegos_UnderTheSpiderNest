using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class HP : MonoBehaviour
{
    public GameObject[] hpImage;
    public int playerHP = 3;
    public GameObject PowerUps;

    bool isInvulnerable;

    private Animator animator;


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

        if (PowerUps != null)
            PowerUps.SetActive(false);

        Debug.Log("Jugador muere");
        Invoke(nameof(ChangeGameOverScene), 2f);
    }

    void ChangeGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
