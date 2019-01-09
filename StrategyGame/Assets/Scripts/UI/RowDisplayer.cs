using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RowDisplayer : MonoBehaviour
{
    public List<BuildingButton> displayers;

    void Awake()
    {
        ResizeDisplayers();
    }

    public void ResizeDisplayers()
    {
        displayers = GetComponentsInChildren<BuildingButton>().ToList();
    }

    public void SetDisplayers(List<BuildingData> data)
    {
        for(int i = 0; i < data.Count; i++)
        {
            displayers[i].Set(data[i]);
        }
    }

}
