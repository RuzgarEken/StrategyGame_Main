using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjeData : ScriptableObject
{
    [Header("Map Object")]
    public string type;
    public string name;
    public bool areaFiller;
    public bool nonwalkable;
    public Sprite image;
    public int width;
    public int height;
    public Color defaultColor;

}
