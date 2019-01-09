using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/MapObjects/Building")]
public class BuildingData : MapObjeData
{
    [Header("Building")]
    public SoldierData producableUnit;
}
