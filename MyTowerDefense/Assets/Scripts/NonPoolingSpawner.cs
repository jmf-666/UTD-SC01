using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPoolingSpawner : MonoBehaviour, ISpawner
{
    

    public void SpawnElement(GameObject prefab)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        GameManager.instance.EnemiesAlive++;
    }

    public IEnumerator SpawnWave(WaveData data)
    {
        PlayerStatsManager.instance.Rounds++;

        for (int i = 0; i < data.Count; i++)
        {
            SpawnElement(data.Prefab);
            yield return new WaitForSeconds(data.Rate);
        }
    }

}
