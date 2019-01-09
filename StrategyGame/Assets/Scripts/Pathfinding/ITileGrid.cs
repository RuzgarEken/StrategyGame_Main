using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileGrid : MonoBehaviour
{
    public abstract bool Passable(Index index);
    public abstract bool Empty(Index index);
    public abstract bool InBounds(Index index);

}
