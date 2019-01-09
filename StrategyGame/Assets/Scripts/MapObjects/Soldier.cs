using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Soldier : MapObje
{
    [Header("Soldier")]
    [Space(20)]

    [Header("Data")]
    [ReadOnly] public Instance_Soldier soldierInstance;

    public void Set(Instance_Soldier soldierInstance)
    {
        this.soldierInstance = soldierInstance;
        this.soldierInstance.E_PositionChanged += PositionChanged;
        spriteRenderer.color = soldierInstance.currentColor;

        base.SetData(soldierInstance);
    }

    public void Clear()
    {
        if(soldierInstance != null)
        {
            soldierInstance.E_PositionChanged -= PositionChanged;
            soldierInstance = null;
        }
    }

    private void PositionChanged()
    {
        if(E_PositionChanged != null)
            E_PositionChanged.Invoke(this);
    }

    public delegate void D_PositionChanged(Soldier source);
    public event D_PositionChanged E_PositionChanged;

}
