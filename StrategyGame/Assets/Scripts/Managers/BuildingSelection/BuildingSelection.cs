using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    [Header("Data")]
    public BuildingInstanceHolder selectedBuilding;

    [Header("Events")]
    public GameEvent_BuildingInstance E_BuildingSelected;
    public GameEvent E_ClearSelection;

    [Header("Components")]
    public ClickedLayerObjeGetter_Building buildingGetter;

    Building tempBuilding;
    public void SelectBuilding()
    {
        tempBuilding = null;
        buildingGetter.GetLayerObjeByMousePosition(ref tempBuilding);
        if(tempBuilding != null)
        {
            selectedBuilding.selectedBuildingInstance = tempBuilding.buildingInstance;
            E_BuildingSelected.Raise(selectedBuilding.selectedBuildingInstance);
        }
    }

    public void ClearSelection()
    {
        selectedBuilding.selectedBuildingInstance = null;
        E_ClearSelection.Raise();
    }

}
