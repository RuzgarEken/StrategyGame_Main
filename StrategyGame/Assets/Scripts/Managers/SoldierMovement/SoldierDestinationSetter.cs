using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDestinationSetter : MonoBehaviour
{
    [Header("Components")]
    public InstanceManager instanceManager;

    [Header("Data")]
    public SelectedSoldiers selectedSoldiers;

    public void MoveSelectedSoldiers(Index tileIndex){
        if(!instanceManager.Passable(tileIndex))
            return;
        if(selectedSoldiers.soldiers.Count == 0)
            return;

        for(int i=0;i<selectedSoldiers.soldiers.Count;i++){
            
            //soldierSelection.selectedSoldiers[i].SetDestination();
        }
    }

}
