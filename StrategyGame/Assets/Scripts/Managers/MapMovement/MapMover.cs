using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMover : MonoBehaviour
{
    [Header("Settings")]
    public float mapSpeed;
    public Transform mapParent;

    public void Move(Vector2 destinationVector)
    {
        mapParent.transform.position += (Vector3)destinationVector * mapSpeed * Time.deltaTime;
    }

}
