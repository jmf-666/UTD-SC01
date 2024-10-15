using System;       
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "MyTowerDefense/GameManager")]
public class GameManager : ManagedObject
{

    public static GameManager instance;


    protected override void OnBegin()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuilderManager in scene!");
            return;
        }
        instance = this;

        Debug.Log("Test");
        PlayerStatsManager.instance.OnLivesChange += CheckWinLose;
        OnEnemiesAliveChange += CheckWinLose;
        nextLevel = startLevel;
        enemiesAlive = 0;
        waveEnded = false;
    }

    protected override void OnEnd()
    {
      
    }

    void CheckWinLose()
    {
        if (PlayerStatsManager.instance.Lives == 0)
        {
            PlayerStatsManager.instance.Initialize();
            LoadLevel(loseLevel, LoadSceneMode.Single);
        } else
        {
            if (waveEnded && enemiesAlive == 0)
            {
                nextLevel = actualLevel.NextLevelName;
                LoadLevel(winLevel, LoadSceneMode.Additive);
            }
        }
    }

    
    [SerializeField] private LevelData[] levels;
    [SerializeField] private string winLevel;
    [SerializeField] private string loseLevel;
    [SerializeField] private string startLevel;
    [SerializeField] private bool waveEnded;
    [SerializeField] private IFader fader;

    public delegate void OnFadeDelegate();
    public event OnFadeDelegate OnFade;                   
    public event Action OnEnemiesAliveChange;

    private Transform levelTarget;  
    private LevelData actualLevel;
    private string nextLevel;
    private int enemiesAlive;

    public void LoadLevel(string levelName, LoadSceneMode mode)
    {
        waveEnded = false;
        enemiesAlive = 0;
        OnFade?.Invoke();
        SceneManager.LoadScene(levelName, mode);
    }

    public Transform LevelTarget { get => levelTarget; set => levelTarget = value; }  
    public int EnemiesAlive { get => enemiesAlive; set
        {
            enemiesAlive = value;
            if (OnEnemiesAliveChange != null)
                OnEnemiesAliveChange();
        }
    }
    public bool WaveEnded { get => waveEnded; set => waveEnded = value; }
    public string NextLevel { get => nextLevel; set => nextLevel = value; }

    public LevelData GetActualLevel()
    {
        foreach (LevelData level in levels) {
            if (SceneManager.GetActiveScene().name == level.name)
            {
                actualLevel = level;
                return level;
            }
        }
        actualLevel = null;
        return null;
    }
}
