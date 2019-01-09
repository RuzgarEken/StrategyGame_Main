using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MapObje
{
    [Header("Building")]
    [Space(20)]

    [Header("Data")]
    public FloatVariable tileSize;
    [ReadOnly] [SerializeField] public Instance_Building buildingInstance;

    [Header("Components")]
    public BoxCollider2D boxCollider;

    public void Set(Instance_Building buildingInstance)
    {
        this.buildingInstance = buildingInstance;
        spriteRenderer.color = buildingInstance.currentColor;
        base.SetData(buildingInstance);

        boxCollider.size = new Vector2(buildingInstance.width * tileSize.value, buildingInstance.height * tileSize.value);
    }

}
