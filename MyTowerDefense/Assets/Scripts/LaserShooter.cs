using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer)) ]
public class LaserShooter : MonoBehaviour, IShooter
{
   
    [SerializeField] ParticleSystem impactEffect;
    [SerializeField] Light impactLight;

    private LineRenderer lineRenderer;
    private float damageAmount;
    private float slow;
    private Transform lastTarget;
    IHealth healthComponent;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    public void Initialize(UnitSpecs specs)
    {
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
        
        if (target !=lastTarget)
        {
            lastTarget = target;
            if (!Equals(healthComponent,null))
            {
                healthComponent.OnDieEvent -= DestroySpawnUnit;
                healthComponent = null;
            }
            else
            {
                if (target.TryGetComponent<IHealth>(out IHealth tryComponent))
                {
                    healthComponent = tryComponent;
                    healthComponent.OnDieEvent += DestroySpawnUnit;
                }
            }
        }
        if (!Equals(healthComponent, null))
        {                                      
            healthComponent.TakeDamage(damageAmount * Time.deltaTime);
        }                               

        
        target.GetComponent<ISeeker>().SetSeekSpeed(slow);

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = transform.position - target.position;

        impactEffect.transform.position = target.position;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }

    public void StopShooting()
    {
        if (lineRenderer.enabled)
        {
            lineRenderer.enabled = false;
            impactEffect.Stop();
            impactLight.enabled = false;
        }
    }
}
