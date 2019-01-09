using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool 
{
    [Header("Settings")]
    public StringVariable poolName;
    public Transform parentObje;
    public GameObject poolObje;
    public int defaultNumber;

    [Header("Instances")]
    public List<GameObject> activeObjects = new List<GameObject>();
    public List<GameObject> pasiveObjects = new List<GameObject>();

}
