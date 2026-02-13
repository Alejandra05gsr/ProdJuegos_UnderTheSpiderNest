using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3;
    public float stopDistance;
    int damage = 1;
    public float attackCooldown = 1f;

    Transform player;
    float attackTimer;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Movement();

    }

    void Movement()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance) //Persigue al jugador :)
        {

            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        {
            Attacking();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Attacking();
        }
    }


    public void Attacking()
    {
        animator.SetBool("Attack", true);
        Debug.Log("Attacking" + animator.GetBool("Attacking"));
        DesactiveEnemy();
        player.GetComponent<HP>().TakeDamage(damage);
    }

    public void Dying()
    {
        animator.SetBool("Die", true);
        DesactiveEnemy();
        Invoke(nameof(Desvanecer), 2f);
    }

    void Desvanecer()
    {
        //Fade de desvanecer con tween
        gameObject.SetActive(false);
        GameManager.instance.EnemyDefeated();
    }

    void DesactiveEnemy()
    {
        speed = 0;
        this.gameObject.GetComponent<Collider>().enabled = false;
    }


}
