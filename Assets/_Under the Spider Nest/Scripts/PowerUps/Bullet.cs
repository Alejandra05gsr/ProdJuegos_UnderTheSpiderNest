using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool isbazookaBullet;
    public GameObject explosionZone;

    Rigidbody rb;
    bool exploded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        explosionZone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (isbazookaBullet) //Municion de bazooka
        {
            if (exploded) return;
            exploded = true;
            explosionZone.SetActive(true);
            //Espera unos segundos
            Destroy(gameObject, 0.2f);
        }

        if (collision.gameObject.CompareTag("Enemy") && !isbazookaBullet) //Municion de metralleta
        {
            collision.gameObject.GetComponent<EnemyHP>().Dying();
            Destroy(gameObject);
        }
        
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 0.5f);
    }

}
