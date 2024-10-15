
using System.Collections;
using UnityEngine;

internal interface ISpawner
{
    IEnumerator SpawnWave(WaveData data);
    void SpawnElement(GameObject prefab);
}
