using UnityEngine;

public abstract class Weapons : PowerUps
{
    public float fireRate;
    public float damage;
    public Transform firePoint;
    protected float nextFireTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //if (!isActive) return;
   

        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + (1 / fireRate);

        ShootBehaviour();
    }


    protected abstract void ShootBehaviour();


}
