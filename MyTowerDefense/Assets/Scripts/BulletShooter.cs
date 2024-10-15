using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour, IShooter
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireCountdown;
    [SerializeField] private float fireRate;

    public void Initialize(UnitSpecs specs)
    {
        fireCountdown = specs.FireCountdown / specs.FireRate;
        fireRate = specs.FireRate;
    }
    public bool CoolDown()
    {
        if (fireCountdown <= 0f)
        {
            fireCountdown = 1f / fireRate;
            return true;
        }

        fireCountdown -= Time.deltaTime;
        return false;
    }

    public void Shoot(Transform target)
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        //Bullet bullet = bulletGO.GetComponent<Bullet>();

        //if (bullet != null)
        //    bullet.Seek(target);
    }

    public void StopShooting()
    {
        
    }


}
