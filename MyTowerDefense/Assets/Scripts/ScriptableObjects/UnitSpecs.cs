using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New UnitSpecs", menuName = "MyTowerDefense/Unit Specs", order = 51)]
public class UnitSpecs  : ScriptableObject
{

    [SerializeField] private float range;
    [SerializeField] private bool useLaser;
    [SerializeField] private float damageOverTime;
    [SerializeField] private float slowOverTime;

    [SerializeField] private GameObject impactEffect;        

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float fireCountdown = 0f;

    public float Range { get => range; set => range = value; }
    public bool UseLaser { get => useLaser; set => useLaser = value; }
    public float DamageOverTime { get => damageOverTime; set => damageOverTime = value; }  
    public GameObject ImpactEffect { get => impactEffect; set => impactEffect = value; }   
    public GameObject BulletPrefab { get => bulletPrefab; set => bulletPrefab = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float FireCountdown { get => fireCountdown; set => fireCountdown = value; }
    public float SlowOverTime { get => slowOverTime; set => slowOverTime = value; }
}
