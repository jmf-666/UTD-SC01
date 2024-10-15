using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData", menuName = "MyTowerDefense/Wave Data", order = 51)]
public class WaveData : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int count;
    [SerializeField] private float rate;        

    public GameObject Prefab { get => prefab;}
    public int Count { get => count;}
    public float Rate { get => rate; }                                        
}
