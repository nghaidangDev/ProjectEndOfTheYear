using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    private string nameEnemy;
    private float hpEnemy;
    private float damagedEnemy;
    private float speedEnemy;

    [Header("RangeAttack")]
    private Vector2 spawnCenter;

    public float attackPlayerRadius;
    public float chasingRadius;
    public float attackDistance;

    private bool isChasingPlayer = false;
    private GameObject player;

    private float attackCooldown = 1f; // Time between attacks
    private float lastAttackTime = 0f;

    [Header("Coin")]
    public Health healthEnemy;
    public GameObject coinPrefabs;
    private int coinCount;

    private void Start()
    {
        if (enemyData != null)
        {
            nameEnemy = enemyData.name;
            hpEnemy = enemyData.hp;
            damagedEnemy = enemyData.damaged;
            speedEnemy = enemyData.speed;
        }

        player = GameObject.FindGameObjectWithTag("Player");
        spawnCenter = transform.position;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distanceToSpawn = Vector2.Distance(transform.position, spawnCenter);

        if (distanceToPlayer <= chasingRadius && distanceToSpawn <= chasingRadius)
        {
            isChasingPlayer = true;
        }
        else if (distanceToSpawn > chasingRadius || distanceToPlayer > chasingRadius)
        {
            isChasingPlayer = false;
        }

        if (isChasingPlayer)
        {
            ChasingToPlayer();
        }
        else if (!isChasingPlayer)
        {
            MoveToSpawnCenter(spawnCenter);
        }

        if (healthEnemy.health <= 0)
        {
            Die();

            Destroy(gameObject);
        }
    }

    private void ChasingToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackDistance)
        {
            AttackPlayer();
        }
        else
        {
            MoveTowards(player.transform.position);
        }
    }

    private void MoveToSpawnCenter(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, speedEnemy * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            // Gọi đến script Health của Player để gây sát thương
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamge(damagedEnemy);
                Debug.Log("Enemy attacked Player! Damage: " + damagedEnemy);
            }
        }
    }

    private void MoveTowards(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, speedEnemy * Time.deltaTime);
    }

    private void Die()
    {
        coinCount = Random.Range(1, 3);

        for (int i = 0;  i < coinCount; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            Instantiate(coinPrefabs, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackPlayerRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chasingRadius);
    }
}
