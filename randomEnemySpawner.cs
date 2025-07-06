using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public float spawnRadius = 10f; // The radius around the player to spawn enemies
    public int enemiesToSpawn = 5; // How many enemies to spawn
    public float spawnInterval = 2f; // Time interval between each spawn

    private Transform playerTransform;

    void Start()
    {
        playerTransform = transform; // Assuming this script is attached to the player object
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval before spawning the next enemy
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        // Get a random point within the spawn radius around the player
        float randomAngle = Random.Range(0f, 360f);
        float randomDistance = Random.Range(20f, spawnRadius);

        // Calculate the spawn position using polar coordinates
        float x = playerTransform.position.x + randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float z = playerTransform.position.z + randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        return new Vector3(x, playerTransform.position.y, z); // Keep the same y as the player
    }
}

