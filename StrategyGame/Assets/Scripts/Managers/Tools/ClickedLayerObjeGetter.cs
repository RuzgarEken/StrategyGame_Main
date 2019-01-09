using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedLayerObjeGetter<T> : MonoBehaviour
{
    public LayerMask layer;

    RaycastHit2D hit;
    Vector3 mousePos3D;
    Vector2 mousePos2D;
    public void GetLayerObjeByMousePosition(ref T clickedObje)
    {
        mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos3D = new Vector2(mousePos3D.x, mousePos3D.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.right, 0.001f, layer);
        if (hit.collider != null)
            clickedObje = hit.collider.GetComponent<T>();
    }

}
