using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistsTileGetterOnMap : MonoBehaviour
{
    [Header("Components")]
    public MapSetter mapSetter;

    /// <summary>
    /// Secili tilelarin object poolingden dolayi harita disina cikmis olabilir
    /// Son index kesinlikle harita ustunde olacak ancak
    /// ilk secili tile indexi harita disindaysa ilk tile'a gore yeni kose noktasini hesaplanacak
    /// </summary>
    public void SetFirstIndex(ref Index firstIndex)
    {
        //Ilk tile map range'inin sol tarafinda. kose tile x indexi degis
        if (firstIndex.x < mapSetter.tiles[0][0].index.x)
            firstIndex.x = mapSetter.tiles[0][0].index.x;
        //Ilk tile map range'inin sag tarafinda. kose tile x indexi degis
        else if (firstIndex.x > mapSetter.tiles[mapSetter.height.value - 1][mapSetter.width.value - 1].index.x)
            firstIndex.x = mapSetter.tiles[mapSetter.height.value - 1][mapSetter.width.value - 1].index.x;

        //Ilk tile map range'inin alt tarafinda. kose tile y indexi degis
        if (firstIndex.y < mapSetter.tiles[0][0].index.y)
            firstIndex.y = mapSetter.tiles[0][0].index.y;
        //Ilk tile map range'inin alt tarafinda. kose tile y indexi degis
        else if (firstIndex.y > mapSetter.tiles[mapSetter.height.value - 1][mapSetter.width.value - 1].index.y)
            firstIndex.y = mapSetter.tiles[mapSetter.height.value - 1][mapSetter.width.value - 1].index.y;
    }

    int sumX;
    int sumY;
    int currentX;
    int currentY;
    Tile tempTile;
    public void GetExistsTilesOnTheMap(Index firstIndex, Index lastIndex, ref List<Tile> existsTiles)
    {
        SetFirstIndex(ref firstIndex);
        MapUtils.SetSumValues(firstIndex, lastIndex, out sumX, out sumY);

        for (int i = 0; i <= Mathf.Abs(firstIndex.y - lastIndex.y); i++)
        {
            currentY = firstIndex.y + i * sumY;

            for (int j = 0; j <= Mathf.Abs(firstIndex.x - lastIndex.x); j++)
            {
                currentX = firstIndex.x + j * sumX;

                tempTile = mapSetter.GetTileByIndex(currentX, currentY);
                if (tempTile!=null)
                    existsTiles.Add(tempTile);
            }
        }
    }

}
