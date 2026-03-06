using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spawnable
{
    public GameObject prefab;
    public int weight = 1; // probabilidad relativa
}

public class RandomSpawner : MonoBehaviour
{
    public Spawnable[] objects;

    public int maxObjects = 10;
    public float spawnDelay = 2f;

    private List<GameObject> currentObjects = new List<GameObject>();
    private BoxCollider box;

    void Start()
    {
        box = GetComponent<BoxCollider>();
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            currentObjects.RemoveAll(obj => obj == null);

            if (currentObjects.Count < maxObjects)
            {
                SpawnObject();
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                yield return null;
            }
        }
    }

    void SpawnObject()
    {
        Vector3 pos = GetRandomPoint(box.bounds);

        GameObject prefab = GetRandomPrefab();

        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);

        currentObjects.Add(obj);
    }

    GameObject GetRandomPrefab()
    {
        int totalWeight = 0;

        foreach (Spawnable s in objects)
            totalWeight += s.weight;

        int random = Random.Range(0, totalWeight);

        foreach (Spawnable s in objects)
        {
            if (random < s.weight)
                return s.prefab;

            random -= s.weight;
        }

        return objects[0].prefab;
    }

    Vector3 GetRandomPoint(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}