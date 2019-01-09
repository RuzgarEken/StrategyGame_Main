using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MapObjeDisplayer
{
    [Header("Events")]
    public GameEvent_BuildingData E_Construction;

    [Header("Data")]
    [ReadOnly] [SerializeField] public BuildingData buildingData;

    public void Set(BuildingData buildingData)
    {
        this.buildingData = buildingData;
        base.Set(buildingData);
    }

    public void OnButtonDown()
    {
        StartCoroutine(ActivateConstructionMode());
    }

    IEnumerator ActivateConstructionMode()
    {
        yield return new WaitForEndOfFrame();
        E_Construction.Raise(buildingData);
    }

}
