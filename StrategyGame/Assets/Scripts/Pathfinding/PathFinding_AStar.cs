using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding_AStar
{

    // Someone suggested making this a 2d field.
    // That will be worth looking at if you run into performance issues.
    public Dictionary<Index, Index> cameFrom;
    public Dictionary<Index, float> costSoFar;

    private Index start = new Index();
    private Index goal = new Index();

    public static float Heuristic(Index a, Index b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    // Conduct the A* search
    public PathFinding_AStar(Index start, Index goal, PathFindingGridInterface graph)
    {
        // start is current sprite Location
        this.start.Set(start);
        // goal is sprite destination eg tile user clicked on
        this.goal.Set(goal);

        cameFrom = new Dictionary<Index, Index>();
        costSoFar = new Dictionary<Index, float>();

        // add the cross product of the start to goal and tile to goal vectors
        // Vector3 startToGoalV = Vector3.Cross(start.vector3,goal.vector3);
        // Location startToGoal = new Location(startToGoalV);
        // Vector3 neighborToGoalV = Vector3.Cross(neighbor.vector3,goal.vector3);

        // frontier is a List of key-value pairs:
        // Location, (float) priority
        PriorityQueue<Index> frontier = new PriorityQueue<Index>();
        // Add the starting location to the frontier with a priority of 0
        frontier.Enqueue(this.start, 0f);

        cameFrom.Add(this.start, this.start); // is set to start, None in example
        costSoFar.Add(this.start, 0f);

        while (frontier.Count > 0f)
        {
                // Get the Location from the frontier that has the lowest
                // priority, then remove that Location from the frontier
            //En az önceliğe sahip sahip olan sınır indexini al
            //ve frontierden bu indexi sil
            Index current = frontier.Dequeue();

            // If we're at the goal Location, stop looking.
            //Eğer aradıgimiz indexteysen aramayi birak
            if (current.Equals(this.goal))
            {
                Debug.Log("Current Equals Goal");
                break;
            }

                // Neighbors will return a List of valid tile Locations
                // that are next to, diagonal to, above or below current
            //Komsular yan, asagi, ust ve caprazlardaki gidilebilir indexleri dondurecek,
            foreach (var neighbor in graph.Neighbors(current))
            {

                    // If neighbor is diagonal to current, graph.Cost(current,neighbor)
                    // will return Sqrt(2). Otherwise it will return only the cost of
                    // the neighbor, which depends on its type, as set in the TileType enum.
                    // So if this is a normal floor tile (1) and it's neighbor is an
                    // adjacent (not diagonal) floor tile (1), newCost will be 2,
                    // or if the neighbor is diagonal, 1+Sqrt(2). And that will be the
                    // value assigned to costSoFar[neighbor] below.
                //Eger komsu su andaki indexe gore caprazda kaliyorsa grap.cost Sqrt(2)
                //dondurecek. Aksi taktirde sadece komsunun costunu dondurecek
                float newCost = costSoFar[current] + graph.Cost(current, neighbor);

                    // If there's no cost assigned to the neighbor yet, or if the new
                    // cost is lower than the assigned one, add newCost for this neighbor
                //Eger komsuya henuz hic bir cost atanmadiysa yada yeni cost atanmistan daha 
                //kucuk ise, yeni costu bu komsu icin ata
                if (!costSoFar.ContainsKey(neighbor) || newCost < costSoFar[neighbor])
                {

                        // If we're replacing the previous cost, remove it
                    //Eger onceki costu degistiriyorsak onceki costu sil
                    if (costSoFar.ContainsKey(neighbor))
                    {
                        costSoFar.Remove(neighbor);
                        cameFrom.Remove(neighbor);
                    }

                    costSoFar.Add(neighbor, newCost);
                    cameFrom.Add(neighbor, current);
                    float priority = newCost + Heuristic(neighbor, this.goal);
                    frontier.Enqueue(neighbor, priority);
                }
            }
        }
    }

    // Return a List of Locations representing the found path
    public List<Index> GetPath()
    {
        List<Index> path = new List<Index>();
        Index current = goal;

        //path.Add(current);

        while (!current.Equals(start))
        {
            if (!cameFrom.ContainsKey(current))
            {
                MonoBehaviour.print("cameFrom does not contain current.");
                return new List<Index>();
            }
            path.Add(current);
            current = cameFrom[current];
        }
        //path.Add(start);
        path.Reverse();
        return path;
    }

}
