using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    [Header("Variables")]
    public StringVariable soldierType;

    [Header("Data")]
    public BuildingInstanceHolder selectedBuilding;

    [Header("Components")]
    public MapSetter mapSetter;
    public InstanceManager instanceManager;
    public PoolController poolController;
    public SoldierPositioner soldierPositioner;
    public NextPossibleSpawnPointHolder nextPossibleSpawnPointHolder;

    Index tempPoint;
    Vector3 spawnPosition;
    public void OnSpawnSoldier(SoldierData soldierData)
    {
        if (nextPossibleSpawnPointHolder.UsingSamePoint())
            tempPoint = soldierPositioner.GetPos();
        else
            tempPoint = soldierPositioner.SearchAvailablePosition(selectedBuilding.selectedBuildingInstance.index, selectedBuilding.selectedBuildingInstance.lastIndex);

        instanceManager.NewSoldier(soldierData, tempPoint);
    }

}
