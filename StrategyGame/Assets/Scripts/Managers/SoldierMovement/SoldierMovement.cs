using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    [Header("Components")]
    public PathFindingGridInterface pathFinderGridInterface;
    public SoldierPositioner soldierPositioner;
    public ClickedLayerObjeGetter_Tile tileGetter;
    public InstanceManager instanceManager;
    public MapSetter mapSetter;

    [Header("Data")]
    public SoldierInstancesHolder selectedSoldiers;

    [Header("Events")]
    public GameEvent_Index fillTile;
    public UnityEngine.Events.UnityEvent E_SoldiersMoved;
    public UnityEngine.Events.UnityEvent E_SoldierMovementFinished;

    [Header("Instances")]
    [ReadOnly] [SerializeField] List<Instance_Soldier> soldiersOnMove = new List<Instance_Soldier>();

    Index tempGoal = new Index();
    Tile clickedTile;
    Index goal = new Index();
    PathFinding_AStar pathfinder;
    public void NewMovement()
    {
        if (selectedSoldiers.soldiers.Count == 0)
            return;

        E_SoldiersMoved.Invoke();

        tileGetter.GetLayerObjeByMousePosition(ref clickedTile);
        goal.Set(clickedTile.index);

        for(int i = 0; i < selectedSoldiers.soldiers.Count; i++)
        {
            //Remove if there is conflicted soldier
            RemoveConflictedSoldier(selectedSoldiers.soldiers[i]);

            if (i == 0)
                tempGoal.Set(soldierPositioner.SearchAvailablePosition(goal));
            else
                tempGoal.Set(soldierPositioner.GetPos());

            pathfinder = new PathFinding_AStar(selectedSoldiers.soldiers[i].index, tempGoal, pathFinderGridInterface);
            selectedSoldiers.soldiers[i].SetDestination(pathfinder.GetPath());
            soldiersOnMove.Add(selectedSoldiers.soldiers[i]);
        }
    }

    void FixedUpdate(){
        if(soldiersOnMove!=null && soldiersOnMove.Count > 0)
            MoveSoldiers();
    }

    bool changedSuccessfully;
    Instance_Soldier tempSoldier;
    Vector2 direction;
    private void MoveSoldiers(){
        for(int i=0;i<soldiersOnMove.Count;i++){
            tempSoldier = soldiersOnMove[i];

            //Askerin yonunu ayarla
            direction = (Index.ToVector2(tempSoldier.destination[tempSoldier.currentDestinationIndex]) - tempSoldier.position).normalized;

            //Askeri yurut
            tempSoldier.SetPosition(tempSoldier.position + direction * tempSoldier.soldierSpeed * Time.deltaTime);

            //Siradaki noktaya varip varmadigini kontrol ediyor
            if (tempSoldier.Arrived())
            {
                tempSoldier.position = tempSoldier.currentDestination;

                instanceManager.ChangeInstancePosition(tempSoldier, tempSoldier.destination[tempSoldier.currentDestinationIndex]);//Set Soldier Current Index
                mapSetter.ActivateSoldier(tempSoldier);
                //fillTile.Raise(tempSoldier.index);
                
                tempSoldier.currentDestinationIndex++;
                if(tempSoldier.destination.Count == tempSoldier.currentDestinationIndex)    //Asker istenilen yere vardi
                {
                   
                    soldiersOnMove.RemoveAt(i);
                    i--;
                    tempSoldier.ClearDestination();

                    if (soldiersOnMove.Count == 0)
                        E_SoldierMovementFinished.Invoke();
                }
                else    //Siradaki nokta ayarlamasi
                {
                    tempSoldier.currentDestination = Index.ToVector2(tempSoldier.destination[tempSoldier.currentDestinationIndex]);
                }
            }
        }
    }

    private void RemoveConflictedSoldier(Instance_Soldier soldier)
    {
        for(int i = 0; i < soldiersOnMove.Count; i++)
        {
            if(soldiersOnMove[i] == soldier)
            {
                soldiersOnMove.RemoveAt(i);
                return;
            }
        }
    }

}
