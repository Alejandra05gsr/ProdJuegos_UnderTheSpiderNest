using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool instance;

    public ParticleSystem particlePrefab;
    public int poolSize = 20;

    private Queue<ParticleSystem> pool = new Queue<ParticleSystem>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            ParticleSystem p = Instantiate(particlePrefab, transform);
            p.gameObject.SetActive(false);
            pool.Enqueue(p);
        }
    }

    public void PlayParticle(Vector3 position, Quaternion rotation)
    {
        ParticleSystem p;

        if (pool.Count > 0)
        {
            p = pool.Dequeue();
        }
        else
        {
            p = Instantiate(particlePrefab, transform);
        }

        p.transform.position = position;
        p.transform.rotation = rotation;

        p.gameObject.SetActive(true);
        p.Play();

        StartCoroutine(ReturnToPool(p));
    }

    System.Collections.IEnumerator ReturnToPool(ParticleSystem p)
    {
        var main = p.main;

        yield return new WaitForSeconds(main.duration + main.startLifetime.constant);

        p.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        p.gameObject.SetActive(false);

        pool.Enqueue(p);
    }
}
