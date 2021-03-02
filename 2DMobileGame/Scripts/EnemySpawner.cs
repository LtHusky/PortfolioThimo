using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // VARIABLES
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    int randomSpawnpoint, randomEnemy;
    public static bool spawnAllowed;

    // FUNCTIONS
    void Start()
    {   // Continue spawning enemies.
        spawnAllowed = true;
        InvokeRepeating ("SpawnEnemy", 0f, 1f);
    }

    public void SpawnEnemy()
    {   // Spawn enemy at spawnpoint.
        if (spawnAllowed == true)
        {
            randomSpawnpoint = Random.Range(0, spawnPoints.Length);
            randomEnemy = Random.Range(0, enemies.Length);
            Instantiate(enemies[randomEnemy], spawnPoints[randomSpawnpoint].position, Quaternion.identity);
        }
    }
}