using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed = 3;
    public GameObject player;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        Quaternion toRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 0.1f);
        animator.SetBool("Walking", true);
    }

}
