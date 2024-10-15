using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnUnitData", menuName = "MyTowerDefense/SpawnUnit Data", order = 51)]
public class SpawnUnitData : ScriptableObject
{
    [SerializeField] private float startSpeed = 10f;
    [SerializeField] private float startHealth = 100;
    [SerializeField] private int worth = 50;
    [SerializeField] private GameObject deathEffect;

    public float StartSpeed { get => startSpeed; set => startSpeed = value; }
    public float StartHealth { get => startHealth; set => startHealth = value; }
    public int Worth { get => worth; set => worth = value; }
    public GameObject DeathEffect { get => deathEffect; set => deathEffect = value; }
}
