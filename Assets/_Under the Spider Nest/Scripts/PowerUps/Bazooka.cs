using UnityEngine;

public class Bazooka : Weapons
{

    public GameObject bazookaBulletPrefab;
    public CameraShake cameraShake;

    [Header("Shake Weapon")]
    public float amplitude = 5;
    public float frequency = 3;
    public float duration = 1.0f;

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
        Instantiate(bazookaBulletPrefab, firePoint.position, firePoint.rotation);
        cameraShake.ShakeCamera(amplitude, frequency, duration);
    }

}
