using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMKShooter : MonoBehaviour, IShooter
{
    private GameObject impactEffect;

    private float damageAmount;
    private float slow;
    private Transform lastTarget;
    IHealth healthComponent;

    public void Initialize(UnitSpecs specs)
    {
        impactEffect = specs.ImpactEffect;
        damageAmount = specs.DamageOverTime;
        slow = specs.SlowOverTime;
    }
    public bool CoolDown()
    {
        return true;
    }

    public void DestroySpawnUnit()
    {
        if (lastTarget == null)
        {

            return;
        }
        if (lastTarget.TryGetComponent<SpawnUnit>(out SpawnUnit spawnUnitComponent))
        {
            PlayerStatsManager.instance.Money += spawnUnitComponent.Data.Worth;
            GameManager.instance.EnemiesAlive--;
            if (!Equals(healthComponent, null))
            {
                healthComponent.OnDieEvent -= DestroySpawnUnit;
                healthComponent.Garbage();
                healthComponent = null;
            }
            lastTarget = null;
        }
    }

    public void Shoot(Transform target)
    {
        if (target != null)
        {
            lastTarget = target;
            if (target.TryGetComponent<IHealth>(out IHealth tryComponent))
            {
                healthComponent = tryComponent;
                healthComponent.OnDieEvent += DestroySpawnUnit;
                healthComponent.TakeDamage(damageAmount);
            }
            GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject, 0.1f);
        }
    }



    public void StopShooting()
    {
       
    }
}
