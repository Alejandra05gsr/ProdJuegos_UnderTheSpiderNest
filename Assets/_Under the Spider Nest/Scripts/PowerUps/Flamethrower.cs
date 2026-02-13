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
        
    }

    protected override void ShootBehaviour()
    {
        insecticide.Play();
    }

}
