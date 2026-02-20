using UnityEngine;

public class Flamethrower : Weapons
{

    public GameObject insecticide;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        insecticide.gameObject.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf) return;

        if (Input.GetMouseButton(0))
        {
                ShootBehaviour();
        }
        else
        {
            insecticide.gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }


    protected override void ShootBehaviour()
    {
        insecticide.gameObject.GetComponent<ParticleSystem>().Play();
        Debug.Log("Insecticida activo");
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo alcanzado por el insecticida");
            other.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }

}
