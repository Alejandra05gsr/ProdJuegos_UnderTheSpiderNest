using DG.Tweening;
using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3;
    public float stopDistance;
    int damage = 1;
    public float attackCooldown = 1f;
    bool isMoving;
    bool canAttack;


    Transform player;
    float attackTimer;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        isMoving = true;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Movement();

    }

    void Movement()
    {
        if (!isMoving) return;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance) //Persigue al jugador :)
        {

            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
            transform.LookAt(player);
        }
        else
        {
            if (Time.time >= attackTimer)
            {
                if (!canAttack) return;

                 StartCoroutine(Attacking());
                 attackTimer = Time.time + attackCooldown;
            }

        }
    }


    IEnumerator Attacking()
    {
        player.GetComponent<HP>().TakeDamage(damage);
        DesactiveEnemy();
        yield return new WaitForSeconds(2);
        ActiveEnemy();

    }

    public void DesactiveEnemy()
    {
        animator.SetBool("Attack", true);
        this.gameObject.GetComponent<Collider>().enabled = false;
        isMoving = false;
        canAttack = false;
    }

    public void ActiveEnemy()
    {
        animator.SetBool("Attack", false);
        this.gameObject.GetComponent<Collider>().enabled = true;
        isMoving = true;
        canAttack = true;
    }


}
