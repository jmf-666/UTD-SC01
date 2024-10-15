using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour 
{
    IAimer aimer;
    IShooter shooter;
    [SerializeField] private UnitSpecs specs;
    private Transform target;
    // Start is called before the first frame update
    void Awake()
    {
        aimer = GetComponent<IAimer>();
        shooter = GetComponent<IShooter>();
        shooter.Initialize(specs);
        aimer.SetRange(specs.Range);

    }

    // Update is called once per frame
    void Update()
    {
        aimer.GetElements();
        target = aimer.GetNearest();
        if(target != null)
        {
            if (shooter.CoolDown())
            {
                shooter.Shoot(target);
            }
        }  else
        {
            shooter.StopShooting();
        }
    }

}
