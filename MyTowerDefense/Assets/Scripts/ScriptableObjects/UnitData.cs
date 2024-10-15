using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "New UnitData", menuName = "MyTowerDefense/Unit Data", order = 51)]
public class UnitData  : ScriptableObject
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Sprite icon;
    [SerializeField] private int cost;

    [SerializeField] private GameObject upgradedPrefab;
    [SerializeField] private int upgradeCost;

    public int SellAmount()
    {
        return cost / 2;
    }

    public GameObject Prefab
    {
        get { return prefab; }
    }
    public int Cost
    {
        get { return cost; }
    }
    public GameObject UpgradedPrefab
    {
        get { return upgradedPrefab; }
    }
    public int UpgradeCost
    {
        get { return upgradeCost; }
    }
    public Sprite Icon
    {
        get { return icon; }
    }

}
