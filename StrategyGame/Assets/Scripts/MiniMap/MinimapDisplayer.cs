using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapDisplayer : MonoBehaviour
{
    [Header("Components")]
    public Texture2D minimap;
    public InstanceManager instanceManager;
    public MapSetter mapSetter;

    [Header("Variables")]
    public int minimapTileSize;
    public Color filledColor;
    public Color screenBorderColor;
    public IntVariable mapWidth;
    public IntVariable mapHeight;
    public int textureEdgeLength;

    [Header("Data")]
    [ReadOnly] [SerializeField] private Color[,] mapColors = new Color[70, 70];

    void Awake()
    {
        //minimap = new Texture2D(mapWidth.value, mapHeight.value);
        //minimapImage.material.mainTexture = minimap;

        InitializeMinimap();
    }

    private void InitializeMinimap()
    {
        ClearMap();
        SetScreenBorders();
        DrawMap();
    }

    private void ClearMap()
    {
        for (int i = 0; i < 70; i++)
        {
            for(int j = 0; j < 70; j++)
            {
                mapColors[i, j] = Color.white;
            }
        }
    }

    public void UpdateMinimap()
    {
        ClearMap();
        SetCornerIndexes();
        SetFilledArea();
        SetScreenBorders();
        DrawMap();
    }

    int mapLeftDown_X;
    int mapLeftDown_Y;
    int mapRightUp_X;
    int mapRightUp_Y;
    private void SetCornerIndexes()
    {
        mapLeftDown_X = mapSetter.tiles[0][0].index.x - mapWidth.value * 2;
        mapLeftDown_Y = mapSetter.tiles[0][0].index.y - mapHeight.value * 2;

        mapRightUp_X = mapSetter.tiles[mapHeight - 1][mapWidth - 1].index.x + mapWidth.value * 2;
        mapRightUp_Y = mapSetter.tiles[mapHeight - 1][mapWidth - 1].index.y + mapHeight.value * 2;
    }

    private void SetFilledArea()
    {
        for (int i = 0; i< 70; i++)
        {
            for(int j = 0; j < 70; j++)
            {
                if (!instanceManager.Empty(mapLeftDown_X + j, mapLeftDown_Y + i))
                    SetPoint(j, i, filledColor);
            }
        }
    }

    private void SetScreenBorders()
    {
        for (int i = 0; i < mapHeight.value ; i++)
        {
            for (int j = 0; j < mapWidth.value; j++)
            {
                if(j == 0 || j == mapWidth.value - 1 || i == 0 || i == mapHeight.value - 1) 
                    SetPoint((textureEdgeLength / 2 - mapWidth.value / 2 + j), (textureEdgeLength / 2 - mapHeight.value / 2 + i), screenBorderColor);
            }
        }
    }

    private void SetPoint(int x, int y, Color color)
    {
        mapColors[x, y] = color;
    }

    private void DrawMap()
    {
        for(int i = 0; i < 70; i++)
        {
            for(int j = 0; j < 70; j++)
            {
                //DrawPoint(j, i, mapColors[i, j]);
                minimap.SetPixel(j, i, mapColors[j, i]);
            }
        }

        minimap.Apply();
    }

    private void DrawPoint(int x, int y, Color color)
    {
        for(int i = 0; i < minimapTileSize; i++)
        {
            for(int j = 0; j < minimapTileSize; j++)
            {
                minimap.SetPixel(x + j, y + i, color);
            }
        }
    }

}

