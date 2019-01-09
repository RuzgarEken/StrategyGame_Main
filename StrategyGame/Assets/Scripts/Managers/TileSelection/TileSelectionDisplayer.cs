using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectionDisplayer : MonoBehaviour
{
    [Header("Settings")]
    public Color defaultColor;
    public Color enableColor;
    public Color unableColor;

    [Header("Managers")]
    public InstanceManager instanceManager;

    /// <summary>
    /// Bina insasinda ayni yapi kullanilacagindan bina'da sadece bos tilelarin boyanmasi
    /// gerekiyor asker secmede secili her alan yesil olmali
    /// </summary>
    public void PaintTiles(List<Tile> tiles, bool paintOnlyEmptyTiles)
    {
        for(int i=0; i < tiles.Count; i++)
        {
            if (!paintOnlyEmptyTiles || instanceManager.Empty(tiles[i].index))
                tiles[i].spriteRenderer.color = enableColor;
            else
                tiles[i].spriteRenderer.color = unableColor;
        }
    }

    public void ClearColors(List<Tile> tiles)
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            tiles[i].spriteRenderer.color = defaultColor;
        }
    }

}
