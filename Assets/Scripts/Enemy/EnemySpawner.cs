using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public int numberOfObjectsToSpawn = 10;
    public float spawnInterval = 1f;

    private int objectsSpawned = 0;

    private void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
    }

    private void SpawnObject()
    {
        if (objectsSpawned >= numberOfObjectsToSpawn)
        {
            CancelInvoke("SpawnObject");
            return;
        }

        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        objectsSpawned++;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float screenX = Random.Range(0f, 1f);
        float screenY = Random.Range(0f, 1f);
        Vector3 spawnPosition = Vector3.zero;

        if (screenX < 0.5f)
        {
            // Spawn on the left or right edge
            spawnPosition.x = screenX < 0.25f ? -Camera.main.aspect * Camera.main.orthographicSize : Camera.main.aspect * Camera.main.orthographicSize;
            spawnPosition.y = Camera.main.orthographicSize * (screenY * 2f - 1f);
        }
        else
        {
            // Spawn on the top or bottom edge
            spawnPosition.x = Camera.main.aspect * Camera.main.orthographicSize * (screenX * 2f - 1f);
            spawnPosition.y = screenY < 0.25f ? -Camera.main.orthographicSize : Camera.main.orthographicSize;
        }

        return spawnPosition;
    }
}
