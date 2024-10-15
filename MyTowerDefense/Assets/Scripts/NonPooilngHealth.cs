using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPooilngHealth : MonoBehaviour, IHealth
{
    private float health;
    private bool isDead;
    [SerializeField] GameObject deathEffect;
    public event Action OnDieEvent;

    public void SetHealth(float maxHealth)
    {
        health = maxHealth;
    }
    public float GetHealth()
    {
        return health;
    }

    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            OnDieEvent?.Invoke();
            GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
    }

    public void Garbage()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }
}
