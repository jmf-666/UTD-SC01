using UnityEngine;

internal interface IShooter
{
    void Initialize(UnitSpecs specs);
    bool CoolDown();
    void Shoot(Transform target);
    void StopShooting();
}
