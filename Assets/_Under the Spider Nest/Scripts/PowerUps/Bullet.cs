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

        if (collision.gameObject.CompareTag("Enemy"))
        {

            collision.gameObject.GetComponent<EnemyMovement>().Dying();
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.forward * 15f * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }

}
