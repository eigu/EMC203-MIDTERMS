using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    [SerializeField] private List<GameObject> obstaclePrefabs;

    [SerializeField] private int obstaclePerWave;
    [SerializeField] private float waveInterval;
    private float waveTimer;

    private void Start()
    {
        waveTimer = waveInterval;
    }

    private void Update()
    {
        waveTimer -= Time.deltaTime;

        if (waveTimer <= 0)
        {
            SpawnWave();
            waveTimer = waveInterval;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < obstaclePerWave; i++)
        {
            float spawnHeight = Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);

            float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
            float rightEdge = mainCamera.transform.position.x + cameraWidth;

            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            Instantiate(obstaclePrefab, new Vector3(rightEdge, spawnHeight, 0f), Quaternion.identity);
        }
    }
}
