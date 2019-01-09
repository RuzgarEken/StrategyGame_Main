using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Instance_Building : Instance
{
    public SoldierData producableUnit;

    public Index lastIndex;

    public Instance_Building(BuildingData buildingData, Index firstIndex, Index lastIndex)
    {
        producableUnit = buildingData.producableUnit;

        base.Set(buildingData);

        this.index = firstIndex;
        this.lastIndex = lastIndex;
    }

}
