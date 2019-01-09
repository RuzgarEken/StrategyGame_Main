using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectionController : MonoBehaviour, IMouseUser
{
    [Header("Components")]
    public TileSelectionDisplayer tileSelectionDisplayer;
    public ExistsTileGetterOnMap existTileGetter;
    public ClickedLayerObjeGetter_Tile tileGetter;

    [Header("Situation")]
    [ReadOnly] [SerializeField] private SelectedTiles selectedTiles;
    [ReadOnly] [SerializeField] private Index firstIndex = new Index();
    [ReadOnly] [SerializeField] private Index lastIndex = new Index();

    bool clicked;

    void Awake()
    {
        selectedTiles = new SelectedTiles();
    }

    Tile tempTile;
    public void LeftClick()
    {
        tempTile = null;
        tileGetter.GetLayerObjeByMousePosition(ref tempTile);
        if (tempTile == null)
            return;

        firstIndex.Set(tempTile.index);
        lastIndex.Set(firstIndex);

        SelectTiles();
    }

    public void LeftDrag()
    {
        tempTile = null;
        tileGetter.GetLayerObjeByMousePosition(ref tempTile);
        if (tempTile == null)
            return;

        if (!tempTile.index.Equals(lastIndex))
        {
            lastIndex.Set(tempTile.index);

            ClearTiles();
            SelectTiles();
        }
    }

    public void LeftRelease()
    {
        ClearTiles();
    }

    public void RightRelease()
    {
        ClearTiles();
    }

    Index cornerIndex;
    private void SelectTiles()
    {
        existTileGetter.GetExistsTilesOnTheMap(firstIndex, lastIndex, ref selectedTiles.tiles);   //Haritanin disinda olan secili alanlarin cizilmesini engelle
        tileSelectionDisplayer.PaintTiles(selectedTiles.tiles, false);
    }

    private void ClearTiles()
    {
        tileSelectionDisplayer.ClearColors(selectedTiles.tiles);
        selectedTiles.ClearSelection();
    }

}
