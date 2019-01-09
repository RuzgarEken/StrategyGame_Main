using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Instance_Soldier : Instance
{

    [ReadOnly] public float soldierSpeed;

    [ReadOnly] public List<Index> destination;
    [ReadOnly] public int currentDestinationIndex;
    [ReadOnly] public Vector2 currentDestination;

    public Instance_Soldier(SoldierData soldierData, Index index)
    {
        destination = new List<Index>();

        soldierSpeed = soldierData.soldierSpeed;

        base.Set(soldierData);

        this.index = index;
    }

    public void SetPosition(Vector2 newPosition)
    {
        position = newPosition;
        if(E_PositionChanged != null)   
            E_PositionChanged.Invoke();
    }

    public delegate void D_PositionChanged();
    public event D_PositionChanged E_PositionChanged;

    public void SetDestination(List<Index> destination)
    {
        ClearDestination();

        for (int i = 0; i < destination.Count; i++)
        { 
            this.destination.Add(destination[i]);
            if(i==0)
                currentDestination = Index.ToVector2(this.destination[0]);
        }
    }

    public bool Arrived()
    {
        if (Vector2.Distance(currentDestination, position) < 0.05f)
            return true;
        else
            return false;
    }

    public void ClearDestination()
    {
        destination.Clear();
        currentDestinationIndex = 0;
    }

}
