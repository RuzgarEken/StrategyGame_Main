using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSelectionDisplayer : MonoBehaviour
{

    public Color selectedColor;
    public Color defaultColor;

    public void NewSelection(List<Instance_Soldier> soldiers)
    {
        PaintSoldiers(soldiers, selectedColor);
    }

    public void ClearSelection(List<Instance_Soldier> soldiers)
    {
        PaintSoldiers(soldiers, defaultColor);
    }

    public void PaintSoldiers(List<Instance_Soldier> soldiers, Color color) {
        for (int i = 0; i < soldiers.Count; i++)
        {
            soldiers[i].currentColor = color; 
        }
    }

}
