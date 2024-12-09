using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Enemy Setting")]
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnRadius = 10f;

    [Header("Enemy Spawn Setting")]
    public float respawnTime = 7f;
    public int maxEnemies = 5;

    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        if (enemies.Count >= maxEnemies)
        {
            return;
        }

        //Create point random in Spawn Points
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        //Create Enemy in Spawnpoint
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        Vector2 spawnPosition = enemy.transform.position;
        spawnPosition.x = Mathf.Clamp(spawnPosition.x, spawnPoint.position.x - spawnRadius, spawnPoint.position.x + spawnRadius);
        spawnPosition.y = Mathf.Clamp(spawnPosition.y, spawnPoint.position.y - spawnRadius, spawnPoint.position.y + spawnRadius);
        enemy.transform.position = spawnPosition;

        //Add enemies in list
        enemies.Add(enemy);

        //Lisen event
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
