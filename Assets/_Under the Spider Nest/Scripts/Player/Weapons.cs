using UnityEngine;

public class Weapons : PowerUps
{
    public float fireRate;
    public float damage;
    public Transform firePoint;
    protected float nextFireTime;

    public GameObject bulletPrefab;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    void ChangeWeapon()
    {

    }

    protected void Shoot()
    {
        //Cada cierto tiempo se dispara una bala
        if (Time.time > nextFireTime)
        {
            ShootBehaviour();

            //Para determinar el fireRate es dividir entre uno el firate, cuantos disparos se permiten por segundo y sumar eso al timepo actual.
            nextFireTime = Time.time + (1 / fireRate);
        }
    }

    //Función para sobrecargar el disparo
    protected virtual void ShootBehaviour()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
