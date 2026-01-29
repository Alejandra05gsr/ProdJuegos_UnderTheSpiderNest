using UnityEngine;

public class HP : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Muerte :p");
    }
}
