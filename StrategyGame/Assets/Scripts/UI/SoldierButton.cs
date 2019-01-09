using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierButton : MapObjeDisplayer
{
    [Header("Events")]
    public GameEvent_SoldierData E_SpawnSoldier;

    [Header("Data")]
    [ReadOnly] [SerializeField] private SoldierData soldierData;

    public void Set(SoldierData soldierData)
    {
        this.soldierData = soldierData;
        base.Set(soldierData);
    }

    public void Spawn()
    {
        E_SpawnSoldier.Raise(soldierData);
    }

}
