using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectedSoldiers
{
    public List<Instance_Soldier> soldiers;

    public SelectedSoldiers()
    {
        soldiers = new List<Instance_Soldier>();
    }

    public void ClearSelection()
    {
        soldiers.Clear();
    }

    public void SetSelection(List<Instance_Soldier> selectedSoldiers)
    {
        this.soldiers = selectedSoldiers;
    }

}
