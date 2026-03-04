using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public Animator animator;

    public float speed = 5f;
    float rotSpeed = 10f;
    [SerializeField] LayerMask groundMask;

    Vector3 lastMouseDir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = GetMovementInput();

        Rotate(move);
        Movement(move);
        UpdateAnimations(move);
    }

    Vector3 GetMovementInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);
        return move.normalized;
    }

    void Movement(Vector3 move)
    {
        controller.Move(move * speed * Time.deltaTime);
    }

    void Rotate(Vector3 move)
    {
        Vector3 mouseDir = GetMouseDirection();

        if (mouseDir.sqrMagnitude > 0.01f)
        {
            lastMouseDir = mouseDir;
        }

        Vector3 finalDir = lastMouseDir;

        // Si no hay mouse -> usar movimiento
        if (finalDir.sqrMagnitude < 0.01f && move.sqrMagnitude > 0.01f)
            finalDir = move;

        if (finalDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(finalDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        }
    }

    Vector3 GetMouseDirection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundMask))
        {
            Vector3 dir = hit.point - transform.position;
            dir.y = 0;
            return dir.normalized;
        }

        return Vector3.zero;
    }


    void UpdateAnimations(Vector3 move)
    {
        Vector3 localMove = transform.InverseTransformDirection(move);
        animator.SetFloat("MoveX", localMove.x);
        animator.SetFloat("MoveZ", localMove.z);

        //Debug.Log(localMove);
    }

    void ResetPosition()
    {

    }

}
