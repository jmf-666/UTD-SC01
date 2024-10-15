using UnityEngine;

public class BuilderPrefabBased : MonoBehaviour, IBuilder
{
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    public GameObject Build(UnitData unit)
    {
        if (PlayerStatsManager.instance.Money < unit.Cost)
        {
            Debug.Log("Not enough money to build that!");
            return null;
        }

        PlayerStatsManager.instance.Money -= unit.Cost;

        GameObject _unitObject = (GameObject)Instantiate(unit.Prefab, GetBuildPosition(), Quaternion.Euler(rotationOffset));

        //turretBlueprint = blueprint;

        //GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 5f);

        return _unitObject;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    public GameObject Upgrade(UnitData unit, GameObject actualUnitObject)
    {
        
		if (PlayerStatsManager.instance.Money < unit.UpgradeCost)
		{
			Debug.Log("Not enough money to upgrade that!");
			return null;
		}

        PlayerStatsManager.instance.Money -= unit.UpgradeCost;

		//Get rid of the old turret
		Destroy(actualUnitObject);

        //GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        //Destroy(effect, 5f);

        //Build a new one
        GameObject _unitObject = (GameObject)Instantiate(unit.UpgradedPrefab, GetBuildPosition(), Quaternion.identity);
		return _unitObject;                    
    }

    public bool Sell(UnitData unit, GameObject actualUnitObject)
    {
        PlayerStatsManager.instance.Money += unit.SellAmount();

		//GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		//Destroy(effect, 5f);

		Destroy(actualUnitObject);
        return true;
    }
}
