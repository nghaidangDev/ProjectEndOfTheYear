using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float health;
    private float maxHealth = 100f;

    public HealthBar healthBar;

    private void Start()
    {
        //Set data for health
        health = maxHealth;
        healthBar.SetMaxHealth(health);
    }

    public void TakeDamge(float _damaged)
    {
        health -= _damaged;
        //Update health when take damage
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            //
            Debug.Log("Die");   
        }
    }
}
