using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingGridInterface : MonoBehaviour
{
    [Header("Components")]
    public TileGrid grid;

    private static readonly Index[] DIRS = new[]
    {
        Index.right,
        Index.down,
        Index.left,
        Index.up,
        Index.rightUp,
        Index.leftUp,
        Index.rightDown,
        Index.leftDown
    };

    public float Cost(Index a, Index b)
    {
        if (PathFinding_AStar.Heuristic(a, b) == 2f)
        {
            return Mathf.Sqrt(2f);
        }
        return 1;
    }

    public IEnumerable<Index> Neighbors(Index index)
    {
        for(int i = 0; i < DIRS.Length; i++)
        {
            Index tempIndex = new Index(index.x + DIRS[i].x, index.y + DIRS[i].y);
            if (grid.InBounds(tempIndex) && grid.Passable(tempIndex))
            {
                yield return tempIndex;
            }
        }
    }

}
