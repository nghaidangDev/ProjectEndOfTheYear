using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;
    public EnemyAnimations enemyAnimations;

    private GameObject player;

    [SerializeField] private float playerInsideRadios;
    [SerializeField] private float playerAttackRadios;

    private bool isChasingPlayer = false;

    private void Start()
    {
        if (enemyData == null)
        {
            Debug.Log("Enemy is not work");
        }

        if (enemyAnimations == null)
        {
            Debug.Log("Enemy Animations is not work");
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= playerInsideRadios)
        {
            isChasingPlayer = true;
        }
        else if (distanceToPlayer > playerInsideRadios)
        {
            isChasingPlayer = false;
        }

        if (isChasingPlayer)
        {
            ChasingPlayer();
        }
    }

    private void ChasingPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= playerAttackRadios)
        {
            AttackPlayer();
        }
        else
        {
            MoveTowards(player.transform.position);
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Attack Player");
    }

    void MoveTowards(Vector3 target)
    {
        float moveSpeed = enemyData.speed;

        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        enemyAnimations.UpdateAnimations(direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, playerInsideRadios);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackRadios);
    }
}
