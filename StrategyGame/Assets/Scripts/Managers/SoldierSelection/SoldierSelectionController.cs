using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSelectionController : MonoBehaviour, IMouseUser
{
    [Header("Components")]
    public InstanceManager instanceManager;
    public MapSetter mapSetter;
    public SoldierSelectionDisplayer selectedSoldierDisplayer;
    public ClickedLayerObjeGetter_Tile tileGetter;

    [Header("Data")]
    public SoldierInstancesHolder selectedSoldiers;

    [Header("Situation")]
    [ReadOnly] [SerializeField] private Index firstSelectedTileIndex;
    [ReadOnly] [SerializeField] private Index currentSelectedTileIndex;

    bool dragActive;
    bool cancelled;
    void Awake()
    {
        dragActive = false;
        cancelled = true;
    }

    public void LeftClick()
    {
        //Mevcut secili askerleri temizle
        selectedSoldierDisplayer.ClearSelection(selectedSoldiers.soldiers);
        selectedSoldiers.soldiers.Clear();

        //Indexleri ayarla
        tempTile = null;
        tileGetter.GetLayerObjeByMousePosition(ref tempTile);
        if (tempTile == null)
            return;

        firstSelectedTileIndex.Set(tempTile.index);
        currentSelectedTileIndex.Set(firstSelectedTileIndex);

        dragActive = true;
        cancelled = false;
    }

    Tile tempTile;
    public void LeftDrag()
    {
        tempTile = null;
        tileGetter.GetLayerObjeByMousePosition(ref tempTile);
        if (tempTile == null)
            return;
        currentSelectedTileIndex.Set(tempTile.index);
    }

    public void LeftRelease()
    {
        dragActive = false;
        if(!cancelled)
            SelectSoldiers();
    }

    public void RightRelease()
    {
        if (dragActive)
        {
            cancelled = true;
            selectedSoldiers.soldiers.Clear();
            selectedSoldierDisplayer.ClearSelection(selectedSoldiers.soldiers);
            PaintSoldiers();
        }
    }

    private void SelectSoldiers()
    {
        //Secili alandaki askerleri bul
        instanceManager.GetSoldiersInRange(firstSelectedTileIndex, currentSelectedTileIndex, ref selectedSoldiers.soldiers);
        selectedSoldierDisplayer.NewSelection(selectedSoldiers.soldiers);
        PaintSoldiers();
    }
    
    private void PaintSoldiers()
    {
        for(int i = 0; i < mapSetter.activeSoldiers.Count; i++)
        {
            mapSetter.activeSoldiers[i].spriteRenderer.color = mapSetter.activeSoldiers[i].soldierInstance.currentColor;
        }
    }

}
