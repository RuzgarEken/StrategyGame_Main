using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfoDisplayer : MonoBehaviour
{
    public MapObjeDisplayer mapObjeDisplayer;
    public SoldierButton soldierButton;

    [ReadOnly] public Instance_Building buildingData;

    public void Set(Instance_Building buildingData)
    {
        this.buildingData = buildingData;

        mapObjeDisplayer.Set(buildingData);

        if (buildingData.producableUnit != null)
            soldierButton.Set(buildingData.producableUnit);
        else
            soldierButton.Clear();
    }

    public void Clear()
    {
        mapObjeDisplayer.Clear();
        soldierButton.Clear();
    }

}
