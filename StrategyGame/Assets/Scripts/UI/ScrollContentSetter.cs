using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScrollContentSetter : MonoBehaviour
{
    public RectTransform parentObject;
    public float borderChangeValue;
    public DataListContainer items;

    [ReadOnly] [SerializeField] private int currentBorderIndex;

    public Transform contentParent;
    [ReadOnly] [SerializeField] private List<RowDisplayer> rowDisplayers;

    void Awake()
    {
        SetGridDisplayers(); 
    }

    private void SetGridDisplayers()
    {
        rowDisplayers = contentParent.GetComponentsInChildren<RowDisplayer>().ToList();

        for(int i = 0; i < rowDisplayers.Count; i++)
        {
            rowDisplayers[i].SetDisplayers(items.dataListContainer[i].datas);
        }
    }

    RowDisplayer tempDisplayer;
    public void OnBorderChanged(float value)
    {
        if(value == 1)  //Going Up
        {
            if(currentBorderIndex > 0)
            {
                currentBorderIndex--;
                SetContents();
                parentObject.anchoredPosition = new Vector2(parentObject.anchoredPosition.x, parentObject.anchoredPosition.y + borderChangeValue * parentObject.rect.height);
            }
        }
        if(value == -1) //Going down
        {
            if(currentBorderIndex < items.dataListContainer.Count - rowDisplayers.Count)
            {
                currentBorderIndex++;
                SetContents();
                parentObject.anchoredPosition = new Vector2(parentObject.anchoredPosition.x, parentObject.anchoredPosition.y - borderChangeValue * parentObject.rect.height);
            }
        }
    }

    private void SetContents()
    {
        for (int i = 0; i < rowDisplayers.Count; i++)
        {
            rowDisplayers[i].SetDisplayers(items.dataListContainer[currentBorderIndex + i].datas);
        }
    }
    
}
