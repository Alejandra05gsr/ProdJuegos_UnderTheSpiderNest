using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3;
    public float stopDistance = 1.5f;
    int damage = 1;
    public float attackCooldown = 1f;


    Transform player;
    float attackTimer;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("Walking", true);
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
            animator.SetBool("Walking", true);
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player);
        }
        else  //Se detiene y ataca al jugador :(
        {
            //Animaciones
            animator.SetBool("Walking", false);
            animator.SetBool("Attacking", true);

            //Se llama el script de vida del jugador para hacerle daño
            player.GetComponent<HP>().TakeDamage(damage);
            Debug.Log("Attaque a jugador");

        }
    }

    public void Dying()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Die", true);
        speed = 0;
        Invoke(nameof(Desvanecer), 1f);
        Debug.Log("Enemigo muere");
    }

    void Desvanecer()
    {
        this.gameObject.SetActive(false);
    }

}
