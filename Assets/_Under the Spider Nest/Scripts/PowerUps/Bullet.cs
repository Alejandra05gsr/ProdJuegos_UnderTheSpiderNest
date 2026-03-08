using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveBullet();
    }


    void MoveBullet()
    {
        rb.linearVelocity = transform.forward * speed;
    }

   
}
