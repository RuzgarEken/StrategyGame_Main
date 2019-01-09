using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGetter : MonoBehaviour
{
    public LayerMask buildingLayer;

    RaycastHit2D hit;
    Vector3 mousePos3D;
    Vector2 mousePos2D;
    public void GetBuildingByMousePosition(out Building tempTile)
    {
        mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3D = new Vector2(mousePos3D.x, mousePos3D.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.right, 0.001f, buildingLayer);
        if (hit.collider != null)
            tempTile = hit.collider.GetComponent<Building>();
        else
            tempTile = null;
    }

}
