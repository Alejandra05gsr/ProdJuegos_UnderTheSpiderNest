using UnityEngine;

public class Flamethrower : Weapons
{

    public ParticleSystem insecticide;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ShootBehaviour();
        }
    }


    protected override void ShootBehaviour()
    {
        insecticide.Play();
    }

}
