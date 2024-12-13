using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    private string nameEnemy;

    private float hpEnemy;
    private float damagedEnemy;
    private float speedEnemy;

    //private Image imgEnemy;

    [Header("RangeAttack")]
    private Transform spawnCenter;

    public float attackPlayerRadius;
    public float chasingRadius;

    public float attackDistance;

    private bool isChasingPlayer = false;
    private GameObject player;


    private void Start()
    {
        if (enemyData != null)
        {
            nameEnemy = enemyData.name;
            hpEnemy = enemyData.hp;
            damagedEnemy = enemyData.damaged;
            speedEnemy = enemyData.speed;
            //imgEnemy.sprite = enemyData.spriteEnemy;
        }

        player = GameObject.FindGameObjectWithTag("Player");

        spawnCenter = transform;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float distanceToSpawn = Vector2.Distance(transform.position, spawnCenter.position);

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
        else
        {
            MoveToSpawnCenter(spawnCenter.position);
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
        transform.position = Vector2.MoveTowards(transform.position, target, speedEnemy * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        Debug.Log("Attack Player");
    }

    private void MoveTowards(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, target, speedEnemy * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackPlayerRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chasingRadius);
    }
}
