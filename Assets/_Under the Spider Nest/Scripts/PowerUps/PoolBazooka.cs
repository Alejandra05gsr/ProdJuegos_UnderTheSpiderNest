using System.Collections.Generic;
using UnityEngine;

public class PoolBazooka : MonoBehaviour
{
    public static PoolBazooka instance;

    public GameObject bulletPrefab;
    public int poolSize = 30;

    List<GameObject> pool = new List<GameObject>();

    void Awake()
    {
        instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        // Si no hay disponibles, crea otra
        GameObject bullet = Instantiate(bulletPrefab);
        pool.Add(bullet);
        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
