using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HP : MonoBehaviour
{
    public int playerHP = 1;
    public TextMeshProUGUI hpText;
    public GameObject PowerUps;

    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        hpText.text = "HP: " + playerHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        hpText.text = "HP: " + playerHP.ToString();
        if (playerHP <= 0)
        {
            playerHP = 0;
            hpText.text = "HP: " + playerHP.ToString();
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Die", true);
        PowerUps.SetActive(false);
        //Cambiar a la escena de Game Over cuando termine la animacion de muerte
        //Se espera 1 segundo para que se vea la animacion de muerte

        Debug.Log("Jugador muere");
        Invoke(nameof(ChangeGameOverScene), 2f);
    }

    void ChangeGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }
}
