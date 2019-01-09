using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instance
{
    public string type;
    public string name;
    public bool areaFiller;
    public bool nonwalkable;
    public Sprite image;
    public int width;
    public int height;
    public Color defaultColor;

    public Color currentColor;
    public Vector2 position;
    public Index index;

    public void Set(MapObjeData mapObjeData)
    {
        type = mapObjeData.type;
        name = mapObjeData.name;
        areaFiller = mapObjeData.areaFiller;
        nonwalkable = mapObjeData.nonwalkable;
        image = mapObjeData.image;
        width = mapObjeData.width;
        height = mapObjeData.height;
        defaultColor = mapObjeData.defaultColor;

        currentColor = defaultColor;
    }

}
