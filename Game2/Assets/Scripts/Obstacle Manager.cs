using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager: MonoBehaviour
{

    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandomObstacle), 1f, spawnInterval);    
    }

    private void SpawnRandomObstacle() {
        if (obstaclePrefabs == null || obstaclePrefabs.Count == 0) return;

        int idx = Random.Range(0, obstaclePrefabs.Count);

        GameObject prefab = obstaclePrefabs[idx];

        Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
    }
}
