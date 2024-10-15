using UnityEngine;

internal interface IBuilder
{
    Vector3 GetBuildPosition();
    GameObject Build(UnitData unit);
    GameObject Upgrade(UnitData unit, GameObject actualUnitObject);
    bool Sell(UnitData unit, GameObject actualUnitObject);
}
