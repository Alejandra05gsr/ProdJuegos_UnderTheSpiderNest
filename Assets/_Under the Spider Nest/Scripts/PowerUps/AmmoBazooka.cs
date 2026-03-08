using UnityEngine;

public class AmmoBazooka : Bullet
{
    public GameObject explosionZone;

    public float liveTime = 1f;


    protected override void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter(Collision collision)
    {

        ContactPoint contact = collision.contacts[0];
        Instantiate(explosionZone, contact.point, Quaternion.identity);
        ExplostionPool.instance.PlayParticle(contact.point, Quaternion.LookRotation(contact.normal));
        BulletPool.instance.ReturnBullet(gameObject);

        Debug.Log("Collided with: " + collision.gameObject.name);
    }

}
