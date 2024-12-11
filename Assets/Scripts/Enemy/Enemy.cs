using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStates { 
    Idle,
    Moving,
    Attack,
    Dead
}
public class Enemy : MonoBehaviour
{
    public EnemyStates currentStates;

    public EnemyData enemyData;
    public EnemyAnimations enemyAnimations;

    private Health enemyHealth;

    private GameObject player;

    [SerializeField] private float playerInsideRadios;
    [SerializeField] private float playerAttackRadios;

    private bool isChasingPlayer = false;


    private void Start()
    {
        currentStates = EnemyStates.Idle;

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
        switch (currentStates)
        {
            case EnemyStates.Idle:
                HandleIdle();
                break;
            case EnemyStates.Moving:
                HandleMoving();
                break;
            case EnemyStates.Attack:
                break;
            case EnemyStates.Dead:
                HandleDead();
                break;
        }
    }

    private void HandleIdle()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= playerInsideRadios)
        {
            isChasingPlayer = true;
            currentStates = EnemyStates.Moving;
        }
        else if (distanceToPlayer > playerInsideRadios)
        {
            isChasingPlayer = false;
        }
    }

    private void HandleMoving()
    {
        if (isChasingPlayer)
        {
            ChasingPlayer();
        } 
        else if (!isChasingPlayer)
        {
            currentStates = EnemyStates.Idle;
        }
    }

    private void HandleAttack()
    {

    }

    private void HandleDead()
    {
        StartCoroutine(EnemyRespawn());
    }

    IEnumerator EnemyRespawn()
    {
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(7f);

        GetComponent<Collider2D>().enabled = true;
        currentStates = EnemyStates.Idle;
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
