using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float spawnOffset;

    [SerializeField] private float lastSpawnPositionX;

    private float spawnTimer;

    private void Start()
    {
        lastSpawnPositionX = playerTransform.position.x;
        spawnTimer = Random.Range(1, 4);
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        float spawnPositionX = GetCameraRightEdge();

        if (spawnPositionX > lastSpawnPositionX
            && !IsInCameraView(spawnPositionX)
            && spawnTimer <= 0)
        {
            float spawnHeight = Random.Range(-mainCamera.orthographicSize, mainCamera.orthographicSize);

            SpawnObstacle(spawnPositionX, spawnHeight);

            lastSpawnPositionX = spawnPositionX;
            spawnTimer = Random.Range(1, 4);
        }
    }

    private void SpawnObstacle(float xPosition, float yPosition)
    {
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

        Instantiate(obstaclePrefab, new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
    }

    private bool IsInCameraView(float xPosition)
    {
        return xPosition <= GetCameraRightEdge();
    }

    private float GetCameraRightEdge()
    {
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
        return mainCamera.transform.position.x + cameraWidth;
    }
}
