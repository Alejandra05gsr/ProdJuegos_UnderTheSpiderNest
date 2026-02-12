using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5f;

    float rotSpeed = 10f;

    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();   
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(horizontal, 0, vertical);

        controller.Move(move * speed * Time.deltaTime);

        bool isMoving = move.magnitude > 0.01f;

        animator.SetBool("Walking", isMoving);


        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }

        //    animator.SetBool("Walking", false);
    }
}
