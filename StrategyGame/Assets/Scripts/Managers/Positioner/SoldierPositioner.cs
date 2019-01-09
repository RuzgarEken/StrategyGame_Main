using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPositioner : MonoBehaviour
{
    [Header("Components")]
    public InstanceManager instanceManager;

    [Header("Events")]
    public GameEvent_Index E_NextPossibleSpawnPointChanged;

    [ReadOnly] [SerializeField] private Index baseLeftDown = new Index();
    [ReadOnly] [SerializeField] private Index baseRightDown = new Index();
    [ReadOnly] [SerializeField] private Index baseRightUp = new Index();
    [ReadOnly] [SerializeField] private Index baseLeftUp = new Index();

    [ReadOnly] [SerializeField] private int layerCounter;
    [ReadOnly] [SerializeField] private int cornerCounter;
    [ReadOnly] [SerializeField] private int counter;

    [ReadOnly] [SerializeField] private int baseAreaWidth;
    [ReadOnly] [SerializeField] private int baseAreaHeight;

    /// <summary>
    /// bos merkezli pozisyonlama 
    /// </summary>
    public Index SearchAvailablePosition(Index baseIndex)
    {
        return SearchAvailablePosition(baseIndex, baseIndex, Index.zero);
    }

    /// <summary>
    /// Alan merkezli pozisyonlama
    /// </summary>
    public Index SearchAvailablePosition(Index baseFirstIndex, Index baseLastIndex)
    {
        return SearchAvailablePosition(baseFirstIndex, baseLastIndex, Index.rightUp);
    }

    /// <summary>
    /// NextPossibleSpawnPointHolder yardimi ile pozisyonlama
    /// </summary>
    public Index SearchAvailablePosition(Index baseFirstIndex, Index baseLastIndex, Index currentLayerNindex)
    {
        baseLeftDown.Set(baseFirstIndex);
        baseRightDown.Set(baseLastIndex.x, baseFirstIndex.y);
        baseRightUp.Set(baseLastIndex);
        baseLeftUp.Set(baseFirstIndex.x, baseLastIndex.y);

        baseAreaWidth = baseLastIndex.x - baseFirstIndex.x + 1;
        baseAreaHeight = baseLastIndex.y - baseFirstIndex.y + 1;

        counter = currentLayerNindex.x;
        layerCounter = currentLayerNindex.y;
        cornerCounter = GetCornerCounter(layerCounter, counter);

        return GetPos();

    }

    Index spawnPoint;
    public Index GetPos()
    {
        SetEdgeLengths(layerCounter);

        while (true)
        {
            spawnPoint = GetNextIndex();
            counter++;

            if (instanceManager.Empty(spawnPoint))
            {
                return spawnPoint;
            }
        }
    }

    private Index GetNextIndex()
    {
        if(counter == edgeLength)   //Kose noktasina varildi
        {
            counter = 1;
            cornerCounter++;

            if (cornerCounter == 5 || layerCounter == 0)  //Son kose noktasi asildi
            {
                cornerCounter = 1;
                layerCounter++;
                SetEdgeLengths(layerCounter);
            }
        }

        if(layerCounter == 0)
        {
            return baseLeftDown;    //Asker diziliminde en orta nokta
        }

        if(cornerCounter == 1) {
            return baseLeftDown + layerCounter * Index.leftDown + Index.right * counter;
        }
        else if(cornerCounter == 2) {
            return baseRightDown + layerCounter * Index.rightDown + Index.up * counter;
        }
        else if(cornerCounter == 3) {
            return baseRightUp + layerCounter * Index.rightUp + Index.left * counter;
        }
        else if(cornerCounter == 4) {
            return baseLeftUp + layerCounter * Index.leftUp + Index.down * counter;
        }

        else
        {
            Debug.Log("<color=red>HATA: SoldierPositionoer.GetNextIndex() - CornerCounter 4'u gecti");
            return null;
        }
    }

    int edgeLength;
    private void SetEdgeLengths(int layer)
    {
        edgeLength = baseAreaWidth + 2 * layer;
    }

    int tempCounter;
    private int GetCornerCounter(int layer, int counter)
    {
        if (layer == 0)
            return 0;

        tempCounter = counter;
        SetEdgeLengths(layer);

        if (tempCounter <= edgeLength)
            return 1;

        tempCounter -= edgeLength;
        if (tempCounter <= edgeLength)
            return 2;

        tempCounter -= edgeLength;
        if (tempCounter <= edgeLength)
            return 3;

        return 4;
    }

}
