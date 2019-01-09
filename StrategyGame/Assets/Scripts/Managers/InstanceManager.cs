using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : TileGrid
{
    [Header("Data")]
    public PositionVariable cameraPosition;

    [Header("Events")]
    public GameEvent_Index E_NewInstance;

    [Header("Managers")]
    public PoolController poolController;

    [Header("Instances")]
    public Dictionary<int, int, Instance_Building> buildings = new Dictionary<int, int, Instance_Building>();
    public Dictionary<int, int, List<Instance_Soldier>> soldiers = new Dictionary<int, int, List<Instance_Soldier>>();

    int sumX;
    int sumY;

    #region New Instance

    Instance_Building tempBuildingInstance;
    public void NewBuilding(BuildingData buildingData, Index firstIndex, Index lastIndex)
    {
        //Binanin bulundugu her index icin dictionary'de yer aliniyor
        tempBuildingInstance = new Instance_Building(buildingData, new Index(firstIndex), new Index(lastIndex));
        for (int i = 0; i <= Mathf.Abs(firstIndex.y - lastIndex.y); i++)
        {
            for (int j = 0; j <= Mathf.Abs(firstIndex.x - lastIndex.x); j++)
            {
                buildings.Add(firstIndex.x + j, firstIndex.y + i, tempBuildingInstance);
            }
        }
        //buildings.Add(new Instance_Building(buildingData, new Index(firstIndex), new Index(lastIndex)));
        E_NewInstance.Raise(firstIndex);
    }

    public void NewSoldier(SoldierData soldierData, Index index)
    {
        //Gelinecek indexe daha once ilk deger atanamamissa atama yap
        if (!soldiers.ContainsKey(index.x, index.y))
            soldiers.Add(index.x, index.y, new List<Instance_Soldier>());

        soldiers[index.x, index.y].Add(new Instance_Soldier(soldierData, new Index(index)));
        E_NewInstance.Raise(index);
    }

    #endregion

    #region Instance Position Settings
    
    public bool ChangeInstancePosition(Instance_Soldier soldier, Index newIndex)
    {
        //Askerin eski konumunu temizle
        soldiers[soldier.index.x, soldier.index.y].Remove(soldier);

        //Gelinecek indexe daha once ilk deger atanamamissa atama yap
        if (!soldiers.ContainsKey(newIndex.x, newIndex.y))
            soldiers.Add(newIndex.x, newIndex.y, new List<Instance_Soldier>());

        //Askerin indexini degistir
        soldiers[newIndex.x, newIndex.y].Add(soldier);
        soldier.index = newIndex;
        return true;
    }

    #endregion

    #region Tile Situation Checks

    public override bool Passable(Index index)
    {
        if (GetBuilding(index.x, index.y) != null)
            return false;
        else
            return true;
    }

    public override bool InBounds(Index index)
    {
        return true;
    }

    public override bool Empty(Index index)
    {
        return Empty(index.x, index.y);
    }

    public bool Empty(int x, int y)
    {
        if (GetBuilding(x, y) == null && (GetSoldier(x, y) == null || GetSoldier(x, y).Count == 0))
            return true;

        return false;
    }

    public bool AreaEmpty(Index firstIndex, Index lastIndex)
    {
        MapUtils.SetSumValues(firstIndex, lastIndex, out sumX, out sumY);

        for (int i = 0; i <= Mathf.Abs(firstIndex.y - lastIndex.y); i++)
        {
            for (int j = 0; j <= Mathf.Abs(firstIndex.x - lastIndex.x); j++)
            {
                if (!Empty(firstIndex.x + sumX * j, firstIndex.y + sumY * i))
                    return false;
            }
        }

        return true;
    }

    #endregion

    #region Get Instance

    Instance_Soldier tempSoldier;
    List<Instance_Soldier> tempSoldiers;
    public void GetSoldiersInRange(Index firstIndex, Index lastIndex, ref List<Instance_Soldier> soldiers)
    {
        //Secimin ilk ve son noktalari harita uzerinde farklilik gosterdiginden eksenler icin
        //artirma ya da azaltma degerleri ayarlaniyor
        MapUtils.SetSumValues(firstIndex, lastIndex, out sumX, out sumY);

        for(int i=0; i<=Mathf.Abs(firstIndex.y - lastIndex.y); i++)
        {
            for(int j=0; j<=Mathf.Abs(firstIndex.x - lastIndex.x); j++)
            {
                tempSoldiers = GetSoldier(firstIndex.x + sumX * j, firstIndex.y + sumY * i);
                if (tempSoldiers != null)
                {
                    for (int k = 0; k < tempSoldiers.Count; k++)
                    {
                        soldiers.Add(tempSoldiers[k]);
                    }
                }
            }
        }
    }

    public Instance_Building GetBuilding(Index index)
    {
        return GetBuilding(index.x, index.y);
    }

    public Instance_Building GetBuilding(int x, int y) 
    {
        if(buildings.ContainsKey(x, y))
            return buildings[x, y];
        else 
            return null;
    }

    public List<Instance_Soldier> GetSoldier(Index index)
    {
        return GetSoldier(index.x, index.y);
    }

    public List<Instance_Soldier> GetSoldier(int x, int y)
    {
        if (soldiers.ContainsKey(x, y))
            return soldiers[x, y];
        else
            return null;
    }

    #endregion

}