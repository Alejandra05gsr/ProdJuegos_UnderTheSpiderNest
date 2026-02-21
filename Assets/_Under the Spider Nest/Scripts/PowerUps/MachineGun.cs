using UnityEngine;

public class MachineGun : Weapons
{
    public GameObject bulletPrefab;
    public CameraShake cameraShake;

    [Header("Shake Weapon")]
    public float amplitude = 2;
    public float frequency = 1;
    public float duration = 0.3f;

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
        cameraShake.ShakeCamera(amplitude, frequency, duration);
    }

}


