using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionSetter : MonoBehaviour
{
    [Header("Settings")]
    public float checkPositionTime;

    [Header("Components")]
    public InstanceManager instanceManager;
    public TileSelectionDisplayer tileSelectionDisplayer;
    public ExistsTileGetterOnMap existsTileGetter;
    public ClickedLayerObjeGetter_Tile tileGetter;

    [Header("Events")]
    public UnityEngine.Events.UnityEvent E_NewBuilding;

    [Header("Situation")]
    [ReadOnly] [SerializeField] private BuildingData buildingData;
    [ReadOnly] [SerializeField] private SelectedTiles selectedTiles;
    [ReadOnly] [SerializeField] private bool constructionMode;
    [ReadOnly] [SerializeField] private Index cursorIndex;
    [ReadOnly] [SerializeField] private Index buildingFirstIndex;
    [ReadOnly] [SerializeField] private Index buildingLastIndex;

    void Awake()
    {
        buildingFirstIndex = new Index();
        buildingLastIndex = new Index();
        selectedTiles = new SelectedTiles();
        constructionMode = false;
    }

    //On click build displayer button
    public void ActivateConstructionMode(BuildingData buildingData)
    {
        this.buildingData = buildingData;
        constructionMode = true;
    }

    //Left Click
    public void Build()
    {
        if (!constructionMode || buildingData == null)
            return;

        if (instanceManager.AreaEmpty(buildingFirstIndex, buildingLastIndex))
        {
            instanceManager.NewBuilding(buildingData, buildingFirstIndex, buildingLastIndex);
            E_NewBuilding.Invoke();
        }

        CancelConstruction();
    }

    //Right Click
    public void CancelConstruction()
    {
        buildingData = null;
        constructionMode = false;
        
        tileSelectionDisplayer.ClearColors(selectedTiles.tiles);
        selectedTiles.ClearSelection();
    }

    float timer;
    void FixedUpdate()
    {
        if (constructionMode)
        {
            //timer += Time.deltaTime;
            //if(timer >= checkPositionTime)
            //{
                CheckMousePosition();
                timer = 0f;
            //}
        }
    }

    RaycastHit2D hit;
    Tile tempTile;
    private void CheckMousePosition()
    {
        tempTile = null;
        tileGetter.GetLayerObjeByMousePosition(ref tempTile);
        if (tempTile == null)
            return;

        if (!cursorIndex.Equals(tempTile.index))
        {
            //Clear previous color
            tileSelectionDisplayer.ClearColors(selectedTiles.tiles);

            cursorIndex = tempTile.index;

            //Binanin harita uzerindeki konumunu bul
            SetBuildingFirstAndLastIndexes();

            //Harita uzerinde gosterilmeyen tile'lari hesapla
            selectedTiles.ClearSelection();
            existsTileGetter.GetExistsTilesOnTheMap(buildingFirstIndex, buildingLastIndex, ref selectedTiles.tiles);

            //Tilelari boya
            tileSelectionDisplayer.PaintTiles(selectedTiles.tiles, true);
        }
    }

    //Mevcut aktif binanin genislik ve uzunluguna gore harita uzerindeki baslangic ve bitis
    //Pozisyonlarinin ayarlar
    private void SetBuildingFirstAndLastIndexes()
    {
        if(buildingData.width % 2 == 0)
        {
            buildingFirstIndex.x = cursorIndex.x - (buildingData.width / 2 - 1);
            buildingLastIndex.x = cursorIndex.x + buildingData.width / 2;
        }
        else
        {
            buildingFirstIndex.x = cursorIndex.x - buildingData.width / 2;
            buildingLastIndex.x = cursorIndex.x + buildingData.width / 2;
        }

        if (buildingData.height % 2 == 0)
        {
            buildingFirstIndex.y = cursorIndex.y - (buildingData.height / 2 - 1);
            buildingLastIndex.y = cursorIndex.y + buildingData.height / 2;
        }
        else
        {
            buildingFirstIndex.y = cursorIndex.y - buildingData.height / 2;
            buildingLastIndex.y = cursorIndex.y + buildingData.height / 2;
        }

    }

}
