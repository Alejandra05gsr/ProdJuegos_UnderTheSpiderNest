using UnityEngine;
using TMPro;

public class Bazooka : Weapons
{

    public GameObject bazookaBulletPrefab;
    public CameraShake cameraShake;
    public int totalAmmo = 5;
    public int currentAmmo;
    public TextMeshProUGUI ammoText;
    public GameObject imageBazooka;

    [Header("Shake Weapon")]
    public float amplitude = 5;
    public float frequency = 3;
    public float duration = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reload();
        CheckAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0 && Input.GetMouseButton(0))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        if (currentAmmo <= 0) return;

        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + (1 / fireRate);

        currentAmmo--;
        CheckAmmo();

        ShootBehaviour();
    }

    protected override void ShootBehaviour()
    {
        Instantiate(bazookaBulletPrefab, firePoint.position, firePoint.rotation);
        cameraShake.ShakeCamera(amplitude, frequency, duration);
    }

    public void CheckAmmo()
    {
        ammoText.text = (currentAmmo + " / " + totalAmmo);

        if (currentAmmo == 0)
        {
            currentAmmo = 0;
            DeactivatePowerUp();
            imageBazooka.SetActive(false);
            this.gameObject.SetActive(false);
        }
        if (currentAmmo > totalAmmo)
        {
            Reload();
        }

        
    }

    //recargar el arma
    public void Reload()
    {
        currentAmmo = totalAmmo;
        CheckAmmo();
    }



}
