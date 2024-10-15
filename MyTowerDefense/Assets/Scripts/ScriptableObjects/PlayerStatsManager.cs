using UnityEngine;        
using System;

[CreateAssetMenu(menuName = "MyTowerDefense/PlayerStatsManagerManager")]
public class PlayerStatsManager : ManagedObject {

    public static PlayerStatsManager instance;



    protected override void OnBegin()
    {
        if (instance != null)
        {
            Debug.LogError("More than one PlayerStatsManager in scene!");
            return;
        }
        instance = this;

        Initialize();
        Debug.Log("Test Players");
    }

    protected override void OnEnd()
    {
        
    }

    public void Initialize()
    {
        Money = startMoney;
        Lives = startLives;

        Rounds = 0;
    }

    private int money;
    public int startMoney = 400;
    private int lives;
    public int startLives = 20;

    public int Rounds;
    public delegate void OnLivesChangeDelegate();
    public event OnLivesChangeDelegate OnLivesChange;

    public int Money { get => money; set => money = value; }
    public int Lives { get => lives;
        set
        {
            lives = value;
            if (OnLivesChange != null)
                OnLivesChange();
        }
    }
}
