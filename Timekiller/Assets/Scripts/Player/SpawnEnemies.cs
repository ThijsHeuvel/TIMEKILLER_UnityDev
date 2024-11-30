using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private Transform playerTransform;
    [SerializeField] private float spawnRadiusMin = 10.0f;
    [SerializeField] private float spawnRadiusMax = 25.0f;

    public float enemySpawnDelay = 10.0f;
    private float enemySpawnUpTimer = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;

        StartCoroutine(SpawnEnemiesPeriodically());
    }

    private void Update()
    {
        enemySpawnUpTimer -= Time.deltaTime;
        if (enemySpawnUpTimer <= 0)
        {
            enemySpawnDelay = enemySpawnDelay * 0.8f;
            enemySpawnUpTimer = 10.0f * 10.0f / enemySpawnDelay;
        }
    }

    private void SpawnEnemy()
    {
        Debug.Log("Enemy Spawn Delay: " + enemySpawnDelay);
        Debug.Log("Increasing Difficulty in : " + enemySpawnUpTimer + " seconds");
        Vector2 spawnDir = Random.insideUnitCircle.normalized;
        float distance = Random.Range(spawnRadiusMin, spawnRadiusMax);

        Vector2 spawnPosition = (Vector2)playerTransform.position + spawnDir * distance;
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

    IEnumerator SpawnEnemiesPeriodically()
    {
        while (true)
        {
            if (!TakeDamageHandler.IsDead)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(enemySpawnDelay); // Wait for 3 seconds before spawning another enemy
            }
            else
            {
                yield return null;
            }
        }
    }
}
