using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSoldierMovementDisplayer : MonoBehaviour
{
    [Header("Variables")]
    public FloatVariable tileSize;

    [Header("Components")]
    public MapSetter mapSetter;

    [Header("Data")]
    public List<Soldier> activeSoldiers;
    
    void Awake()
    {
        mapSetter.E_SoldierActivated += SoldierActivated;
        mapSetter.E_SoldierDeactivated += RemoveSoldier;
    }

    public void SoldierActivated(Soldier soldier)
    {
        soldier.E_PositionChanged += PositionChanged;
        soldier.soldierInstance.position = Index.ToVector2(soldier.soldierInstance.index);
    }

    public void RemoveSoldier(Soldier soldier)
    {
        activeSoldiers.Remove(soldier);
        soldier.E_PositionChanged -= PositionChanged;
    }

    Tile tempTile;
    public void PositionChanged(Soldier source)
    {
        if (!mapSetter.TileOnMap(source.soldierInstance.index))
            return;

        tempTile = mapSetter.GetTileByIndex(source.soldierInstance.index.x, source.soldierInstance.index.y);
        source.transform.position = tempTile.transform.position + (Vector3)(source.soldierInstance.position - Index.ToVector2(tempTile.index)) * tileSize.value;
    }

}
