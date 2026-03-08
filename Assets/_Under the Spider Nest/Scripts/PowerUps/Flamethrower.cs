using UnityEngine;
using TMPro;

public class Flamethrower : Weapons
{

    public ParticleSystem fire;
    public TextMeshProUGUI ammoText;
    public GameObject damageZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf) return;
        ShootBehaviour();

    }


    protected override void ShootBehaviour()
    {
        if (Input.GetMouseButton(0))
        {
            if (!fire.isPlaying)
                fire.Play();
            damageZone.SetActive(true);
        }
        else
        {
            if (fire.isPlaying)
                fire.Stop();
            damageZone.SetActive(false);
        }
    }

}
