using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesGenerator : MonoBehaviour
{
    private ISpawner spawner;
    private ICounter counter;
    private int waveIndex;
    private int enemiesAlive; 
    private WaveData[] waves;
    private WaveData actualWave;
    private LevelData actualLevel;

    [SerializeField] Text waveCountdownText;
    
    // Start is called before the first frame update
    void Awake()
    {
        spawner = GetComponent<ISpawner>();
        counter = GetComponent<ICounter>();
    }

    private void Start()
    {
        waves = GameManager.instance.GetActualLevel().Waves;
        actualWave = waves[waveIndex];
        enemiesAlive = actualWave.Count;
        actualLevel = GameManager.instance.GetActualLevel();
        counter.SetCounter(actualLevel.TimeBetweenWaves);
    }

    // Update is called once per frame
    void Update()                                                       
    {
        if (enemiesAlive > 0)
        {
            //return;
        }

        
        if (waveIndex == waves.Length)
        {
            //gameManager.WinLevel();
            this.enabled = false;
        }

        if (counter.Count())
        {
            StartCoroutine(spawner.SpawnWave(actualWave));         
            counter.SetCounter(actualLevel.TimeBetweenWaves);
            waveIndex++;
            if (actualLevel.Waves.Length == waveIndex)
            {
                GameManager.instance.WaveEnded = true;
                this.enabled = false;
            }
            return;

        }
        

        waveCountdownText.text = string.Format("{0:00.00}", counter.GetCounter());
    }
}
