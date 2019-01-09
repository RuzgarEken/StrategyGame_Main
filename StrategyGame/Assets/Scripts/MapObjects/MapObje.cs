using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class MapObje : PoolObject
{
    [Header("Map Obje")]
    [Space(20)]

    [Header("Components")]
    public SpriteRenderer spriteRenderer;

    protected void SetData(Instance instance)
    {
        name = instance.name;
        objeType = instance.type;

        spriteRenderer.sprite = instance.image;
    }

}
