using System;          
using UnityEngine;

[CreateAssetMenu(menuName = "MyTowerDefense/BuildManager")]
public class BuildManager : ManagedObject
{

    public static BuildManager instance;


    protected override void OnBegin()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuilderManager in scene!");
            return;
        }
        instance = this;

        selectedUnit = null;
        Debug.Log("Test Build");
    }
    protected override void OnEnd()
    {
        
    }

    [SerializeField] private GameObject buildEffect;
    [SerializeField] private GameObject sellEffect;

    private Transform currentSpot;
	private UnitData selectedUnit;
	private Spot selectedSpot;

	//public NodeUI nodeUI;

	public bool CanBuild { get { return selectedUnit != null; } }
	public bool HasMoney { get { return PlayerStatsManager.instance.Money >= selectedUnit.Cost; } }

	public void SelectSpot (Spot spot)
	{
		if (selectedSpot == spot)
		{
			DeselectSpot();
			return;
		}

        selectedSpot = spot;
        //selectedUnit = null;

		//nodeUI.SetTarget(node);
	}

	public void DeselectSpot()
	{
        selectedSpot = null;
		//nodeUI.Hide();
	}

	public void SelectUnitToBuild (UnitData unit)
	{
        selectedUnit = unit;
        DeselectSpot();
	}

	public UnitData GetUnitToBuild ()
	{
		return selectedUnit;
	}

    public Transform CurrentSpot
    {
        get { return currentSpot; }
        set { currentSpot = value; }
    }

}
