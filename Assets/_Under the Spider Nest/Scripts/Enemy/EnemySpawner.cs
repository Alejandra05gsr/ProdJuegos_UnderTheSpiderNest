using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spiderPrefab;
    public Transform spiderSpawn;
    public float spawnInterval = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSpiders();
    }

    void SpawnSpiders()
    {
        //spawn a spider every spawnInterval seconds
        if (Time.time % spawnInterval < 0.02f)
        {
            Instantiate(spiderPrefab, spiderSpawn.position, spiderSpawn.rotation);
        }

    }

}
