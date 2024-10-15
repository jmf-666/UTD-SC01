using System;
using UnityEngine;

internal interface IHealth
{
    void SetHealth(float maxHealth);
    float GetHealth();
    void TakeDamage(float amount);
    void Die();
    void Garbage();
    event Action OnDieEvent;
}
