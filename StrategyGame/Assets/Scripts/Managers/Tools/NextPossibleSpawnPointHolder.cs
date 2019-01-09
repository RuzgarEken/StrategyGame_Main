using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPossibleSpawnPointHolder : NextPossiblePointHolder
{
    public BuildingInstanceHolder currentSelectedBuilding;
    [ReadOnly] public Instance_Building lastSpawnerBuilding;

    /// <summary>
    /// <para>Arka arkaya asker uretmede islem kolayligi saglar</para>
    /// <para>Her uretimde siradaki uretim noktasinin indexini tutar,</para>
    /// <para>son ureten bina su an uretenle ayni ise </para>
    /// <para>ayni islemleri yapmasina gerek kalmadan direk noktayi dondurur</para>
    /// </summary>
    public override bool UsingSamePoint()
    {
        if (lastSpawnerBuilding != currentSelectedBuilding.selectedBuildingInstance
            || soldiersMoved
        )
        {
            lastSpawnerBuilding = currentSelectedBuilding.selectedBuildingInstance;
            soldiersMoved = false;
            return false;
        }
        else
            return true;
    }

    bool soldiersMoved = false;
    public void SoldiersMoved()
    {
        soldiersMoved = true;
    }

}
