using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContentCreator : MonoBehaviour
{
    public Transform parentTransform;
    public GameObject rowParentObje;
    public GameObject dataDisplayerObje;
    public int rowCount;
    public int columnCount;

    GameObject tempObje;
    void Awake()
    {
        for(int i = 0; i < rowCount; i++)
        {
            tempObje = Instantiate(rowParentObje, parentTransform) as GameObject;
            for(int j = 0; j < columnCount; j++)
            {
                Instantiate(dataDisplayerObje, tempObje.transform);
            }
            tempObje.GetComponent<RowDisplayer>().ResizeDisplayers();
        }
    }

}
