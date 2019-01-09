using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [ReadOnly] public Index index;

    public SpriteRenderer spriteRenderer;

    public void Set(Index index)
    {
        this.index = index;
    }

}
