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
    public Transform respawn;

    public GameObject invulnerable;


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

        if (playerHP <= 0)
        {
            playerHP = 0;
            Die();
        }
        else
        {
            NormalDie();
        }
    }

    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        invulnerable.SetActive(true);
        yield return new WaitForSeconds(5f);
        isInvulnerable = false;
        invulnerable.SetActive(false);
    }

    void NormalDie()
    {
        animator.SetBool("Die", true);

        GetComponent<PlayerMovement>().Die();

        if (powerUps != null)
            powerUps.SetActive(false);

        StartCoroutine(Invulnerable());

        Invoke(nameof(Respawn), 3f);
    }

    void Die()
    {
        //animator.SetBool("Idle", false);
        animator.SetBool("Die", true);

        GetComponent<PlayerMovement>().Die();

        if (powerUps != null)
            powerUps.SetActive(false);

        //this.GetComponent<MaterialFade>().StartFade();
        //gameManager.GetComponent<CameraShake>().ShakeCamera(2,2,2);

        Debug.Log("Jugador muere");
        Invoke(nameof(FadeGameOver), 3f);
    }

    void FadeGameOver()
    {
        fade.GetComponent<Fade>().Fading(true);
    }

    void Respawn()
    {
        animator.SetBool("Die", false);

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.position = respawn.position;
        }
        else
        {
            transform.position = respawn.position;
        }

        transform.rotation = respawn.rotation;

        Debug.Log("Respawn en: " + respawn.position);

        if (powerUps != null)
            powerUps.SetActive(true);

        GetComponent<PlayerMovement>().Respawn();
    }
}
