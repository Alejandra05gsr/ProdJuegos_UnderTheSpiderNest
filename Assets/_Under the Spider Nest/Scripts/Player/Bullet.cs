using UnityEngine;

public class Bullet : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collided with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.forward * 20f * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

}
