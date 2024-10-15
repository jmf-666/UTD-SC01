using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ´LevelData", menuName = "MyTowerDefense/Level Data", order = 51)]
public class LevelData : ScriptableObject
{
    [SerializeField] private WaveData[] waves;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float countdown = 2f;
    [SerializeField] private string nextLevelName;

    public float TimeBetweenWaves { get => timeBetweenWaves; set => timeBetweenWaves = value; }
    public float Countdown { get => countdown; set => countdown = value; }
    public WaveData[] Waves { get => waves;}
    public string NextLevelName { get => nextLevelName;}
}
