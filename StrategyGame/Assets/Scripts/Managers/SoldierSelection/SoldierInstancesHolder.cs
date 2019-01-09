using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameData/SoldierInstancesHolder")]
public class SoldierInstancesHolder : ScriptableObject
{
    public List<Instance_Soldier> soldiers = new List<Instance_Soldier>();
}
