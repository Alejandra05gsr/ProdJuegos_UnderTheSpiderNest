using UnityEngine;

public class Bazooka : Weapons
{

    public GameObject bazookaBulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void ShootBehaviour()
    {
        Instantiate(bazookaBulletPrefab, firePoint.position, firePoint.rotation);
    }

}
