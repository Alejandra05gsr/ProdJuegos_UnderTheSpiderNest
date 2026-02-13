using UnityEngine;

public class MachineGun : Weapons
{
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
            Shooting();
        }
    }


    void Shooting()
    {
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + (1 / fireRate);

        ShootBehaviour();
    }


    protected override void ShootBehaviour()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
