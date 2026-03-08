using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public ParticleSystem fireParticle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            other.gameObject.GetComponent<EnemyHP>().Dying();
        }

        Vector3 spawnPos = other.ClosestPoint(transform.position);

        Instantiate(fireParticle, spawnPos, Quaternion.identity);

    }

}
