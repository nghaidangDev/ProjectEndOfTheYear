using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    public HealthBar healthBar;

    private Enemy enemy;

    private void Start()
    {
        //Set data for health
        health = maxHealth;
        healthBar.SetMaxHealth(health);

        enemy = GetComponent<Enemy>();
    }

    public void TakeDamge(float _damaged)
    {
        health -= _damaged;
        //Update health when take damage
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            health = maxHealth;
            UpdateHealth(health);

            enemy.currentStates = EnemyStates.Dead;
        }
    }

    public void UpdateHealth(float health)
    {
        healthBar.SetHealth(health);
    }
}
