using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SelectedTiles 
{
    public List<Tile> tiles;

    public SelectedTiles()
    {
        tiles = new List<Tile>();
    }

    public void ClearSelection()
    {
        tiles.Clear();
    }

    public void Add(Tile tile)
    {
        tiles.Add(tile);
    }
}
