using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isbazookaBullet;
    public GameObject explosionZone;


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
        if (isbazookaBullet) //Municion de bazooka
        {
            explosionZone.SetActive(true);
            //Espera unos segundos
            Destroy(gameObject,1.5f);
        }

        if (collision.gameObject.CompareTag("Enemy") && !isbazookaBullet) //Municion de metralleta
        {
            collision.gameObject.GetComponent<EnemyHP>().Dying();
        }
        
        if (!collision.gameObject.CompareTag("Player"))
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
