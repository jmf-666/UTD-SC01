using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour
{
    [SerializeField] private SpawnUnitData data;
    private ISeeker seeker;
    private IHealth health;
    [SerializeField] private GameObject autoDestroyPrefab;

    public SpawnUnitData Data { get => data; set => data = value; }

    // Start is called before the first frame update
    void Awake()
    {
        seeker = GetComponent<ISeeker>();
        health = GetComponent<IHealth>();

        health.SetHealth(Data.StartHealth);
        seeker.SetSeekSpeed(Data.StartSpeed);
        seeker.Seek(seeker.GetTarget());
        seeker.OnDestinyEvent += Destiny;
    }

    private void Destiny()
    {
        PlayerStatsManager.instance.Lives--;
        GameObject effect = (GameObject)Instantiate(autoDestroyPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Debug.Log("destiny");
        GameManager.instance.EnemiesAlive--;
        Destroy(gameObject);
    }
}
