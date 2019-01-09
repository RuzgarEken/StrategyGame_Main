using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSetter : MonoBehaviour
{  
    [Header("Settings")]
    public float rangeX;
    public float rangeY;
    public float margin;
    public IntVariable width;
    public IntVariable height;

    [Header("Data")]
    public PositionVariable cameraPosition;

    [Header("Variables")]
    public StringVariable tileObjeType;
    public StringVariable buildingObjeType;
    public StringVariable soldierObjeType;
    public FloatVariable tileSize;

    [Header("Events")]
    public GameEvent_GameObject E_ReturnObjeToPool;

    [Header("Instances")]
    public List<List<Tile>> tiles = new List<List<Tile>>();
    public List<Building> activeBuildings = new List<Building>();
    public List<Soldier> activeSoldiers = new List<Soldier>();

    [Header("Managers")]
    public PoolController poolController;
    public InstanceManager instanceManager;

    bool gameStarted = false;
    public void StartGame()
    {
        CreateMap();
        gameStarted = true;
    }

    void LateUpdate(){
        if(gameStarted)
            CheckCameraRanges();
    }

    Tile tempTile;
    int gridX;
    int gridY;
    List<Tile> innerTiles;
    public void CreateMap(){
        gridY = 0;
        for(int i=-height.value/2; i<height.value/2; i++){
            innerTiles = new List<Tile>();
            gridX = 0;
            for(int j=-width.value/2; j<width.value/2; j++){
                tempTile = poolController.GetPoolObje(tileObjeType.value, cameraPosition.value + new Vector3(j * tileSize.value, i * tileSize.value, 0f)).GetComponent<Tile>();
                tempTile.Set(new Index(gridX, gridY));
                gridX++;
                innerTiles.Add(tempTile);
            }
            gridY++;
            tiles.Add(innerTiles);
        }
    }

    bool rangeChanged;
    public void CheckCameraRanges(){
        //sol alttaki tile'ın camera range durumu kontrol edilerek haritada hareket olup olmadığı kontrol ediliyor

        rangeChanged = false;

        //Harita Sağa ilerlemiş. En soldaki tileları deactivate edip saga yeni tile ekle
        if (tiles[0][0].transform.position.x < cameraPosition.value.x - rangeX - margin)
        {
            rangeChanged = true;

            for(int i=0; i<height.value; i++){
                //Remove Tile 
                tempTile = tiles[i][0]; 
                tiles[i].RemoveAt(0);
                
                //Tile'ın pozisyonunu widht kadar ötele ve sona ekle
                tempTile.index.Set(tempTile.index.x + width.value , tempTile.index.y);
                tempTile.transform.position += new Vector3(width.value * tileSize.value, 0f, 0f);
                tiles[i].Add(tempTile);

            }

            for(int i = 0; i < height.value; i++)
            {
                FillTile(tiles[i][width.value-1]);
            }
        }
        //Harita sola ilerlemis. En sagdaki tileları deactivate et sola yeni tile
        else if (tiles[0][0].transform.position.x > cameraPosition.value.x - rangeX + margin)
        {
            rangeChanged = true;

            for (int i = 0; i < height.value; i++)
            {

                tempTile = tiles[i][width.value - 1];
                tiles[i].RemoveAt(width.value - 1);

                //Add tile 
                tempTile.index.Set(tempTile.index.x - width.value, tempTile.index.y);
                tempTile.transform.position += new Vector3(-width.value * tileSize.value, 0f, 0f);
                tiles[i].Insert(0, tempTile);

            }

            for(int i = 0; i < height.value; i++)
            {
                FillTile(tiles[i][0]);
            }
        }

        //Harita yukari ilerlemis. Alt deactivate Ust yeni tile
        if (tiles[0][0].transform.position.y < cameraPosition.value.y - rangeY - margin)
        {
            rangeChanged = true;

            innerTiles = tiles[0];
            tiles.RemoveAt(0);
            tiles.Add(innerTiles);

            for (int i = 0; i < width.value; i++)
            {
                tempTile = tiles[height.value - 1][i];
                tempTile.index.Set(tempTile.index.x, tempTile.index.y + height.value);
                tempTile.transform.position += new Vector3(0f, height.value * tileSize.value, 0f);

            }

            for (int i = 0; i < width.value; i++)
            {
                FillTile(tiles[height.value - 1][i]);
            }
        }
        //Harita asagi ilerlemis. Ust deactivate Alt yeni tile
        else if (tiles[0][0].transform.position.y > cameraPosition.value.y - rangeY + margin)
        {
            rangeChanged = true;

            innerTiles = tiles[height.value - 1];
            tiles.RemoveAt(height.value - 1);
            tiles.Insert(0, innerTiles);

            for (int i = 0; i < width.value; i++)
            {
                tempTile = tiles[0][i];
                tempTile.index.Set(tempTile.index.x, tempTile.index.y - height.value);
                tempTile.transform.position += new Vector3(0f, -height.value * tileSize.value, 0f);
            }

            for(int i = 0; i < width.value; i++)
            {
                FillTile(tiles[0][i]);
            }
        }

        if (rangeChanged)
        {
            CheckBuildingDeactivation();
            CheckSoldierDeactivation();
        }
    }

    public void CheckBuildingDeactivation()
    {
        //Debug.Log("firstTile = " + tiles[0][0].index.x + " : " + tiles[0][0].index.y + " lastTile = " + tiles[height - 1][width - 1].index.x + " : " + tiles[height - 1][width - 1].index.y);

        for (int i = 0; i < activeBuildings.Count; i++)
        {
            if (!MapUtils.IsAreaIntersectWithOther(
                activeBuildings[i].buildingInstance.index,
                activeBuildings[i].buildingInstance.lastIndex,
                tiles[0][0].index,
                tiles[height.value - 1][width.value - 1].index)
            )
            {
                Debug.Log("Therer is no intersec");
                tempPoolObje = activeBuildings[i].gameObject;
                activeBuildings.RemoveAt(i);
                E_ReturnObjeToPool.Raise(tempPoolObje);
                i--;
            }
        }
    }

    public void CheckSoldierDeactivation()
    {
        for(int i = 0; i < activeSoldiers.Count; i++)
        {
            if(!MapUtils.IsIndexInArea(activeSoldiers[i].soldierInstance.index,
                tiles[0][0].index, 
                tiles[height.value - 1][width.value - 1].index)
            )
            {
                E_SoldierDeactivated.Invoke(activeSoldiers[i]);
                activeSoldiers[i].Clear();
                tempPoolObje = activeSoldiers[i].gameObject;
                activeSoldiers.RemoveAt(i);
                E_ReturnObjeToPool.Raise(tempPoolObje);
                i--;
            }

        }
    }

    Building tempBuilding;
    Soldier tempSoldier;

    Instance_Building tempBuildingInstance;
    Instance_Soldier tempSoldierInstance;
    List<Instance_Soldier> tempSoldierInstances;

    BuildingData tempBuildingData;
    SoldierData tempSoldierData;
    Vector2 offsetVec = new Vector2();
    GameObject tempPoolObje;
    public void FillTile_ControllTileOnMapSituation(Index index)
    {
       if (!TileOnMap(index))
            return;

        FillTile(index);
    }

    public void FillTile(Index index)
    {
        if (AlreadySpawned(index))
            return;

        tempBuildingInstance = instanceManager.GetBuilding(index);
        if(tempBuildingInstance != null)
        {
            MapUtils.GetIndexDistanceToAreaMidPoint(index, tempBuildingInstance.index, tempBuildingInstance.lastIndex, out offsetVec);
                
            tempPoolObje = poolController.GetPoolObje(buildingObjeType.value, GetTileByIndex(index.x, index.y).transform.position + (Vector3)offsetVec);
            tempBuilding = tempPoolObje.GetComponent<Building>();
            tempBuilding.Set(tempBuildingInstance);
            activeBuildings.Add(tempBuilding);
            return;
        }

        tempSoldierInstances = instanceManager.GetSoldier(index);
        if(tempSoldierInstances != null)
        {
            for(int i = 0; i < tempSoldierInstances.Count; i++)
            {
                tempPoolObje = poolController.GetPoolObje(soldierObjeType.value, GetTileByIndex(index.x, index.y).transform.position);
                tempSoldier = tempPoolObje.GetComponent<Soldier>();
                tempSoldier.Set(tempSoldierInstances[i]);
                activeSoldiers.Add(tempSoldier);
                E_SoldierActivated.Invoke(tempSoldier);
            }
        }
    }

    public void ActivateSoldier(Instance_Soldier soldierInstance)
    {
        for(int i = 0; i < activeSoldiers.Count; i++)
        {
            if (activeSoldiers[i].soldierInstance == soldierInstance)
                return;
        }

        if (!MapUtils.PositionInArea(soldierInstance.position, tiles[0][0].index, tiles[height.value - 1][width.value - 1].index))
            return;

        tempPoolObje = poolController.GetPoolObje(soldierObjeType.value);
        tempSoldier = tempPoolObje.GetComponent<Soldier>();
        activeSoldiers.Add(tempSoldier);
        tempSoldier.Set(soldierInstance);
        E_SoldierActivated.Invoke(tempSoldier);
    }

    private void FillTile(Tile tile)
    {
        FillTile(tile.index);
    }

    public bool AlreadySpawned(Index index)
    {
        for(int i = 0; i < activeBuildings.Count; i++)
        {
            if (MapUtils.IsIndexInArea(index, activeBuildings[i].buildingInstance.index, activeBuildings[i].buildingInstance.lastIndex))
                return true;
        }

        return false;
    }

    public bool TileOnMap(Index index)
    {
        return MapUtils.IsIndexInArea(index, tiles[0][0].index, tiles[height.value - 1][width.value - 1].index);
    }

    public Tile GetTileByIndex(int x, int y)
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            for(int j = 0; j < tiles[i].Count; j++)
            {
                if (tiles[i][j].index.x == x && tiles[i][j].index.y == y)
                    return tiles[i][j];
            }
        }

        return null;
    }

    public delegate void D_SoldierActivated(Soldier source);
    public event D_SoldierActivated E_SoldierActivated;

    public delegate void D_SoldierDeactivated(Soldier source);
    public event D_SoldierDeactivated E_SoldierDeactivated;

}
