using UnityEngine;

public class AmmoMG : Bullet
{
    public ParticleSystem hitParticle;
    public float liveTime = 0.3f;

    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHP>().Dying();
        }

        if (!collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke();
            BulletPool.instance.ReturnBullet(gameObject);
        }

        //ContactPoint contact = collision.contacts[0];
        //ParticlePool.instance.PlayParticle(contact.point, Quaternion.LookRotation(contact.normal));

    }

    void OnEnable()
    {
        Invoke(nameof(ReturnBullet), liveTime);
    }

    void ReturnBullet()
    {
        BulletPool.instance.ReturnBullet(gameObject);
    }
}
