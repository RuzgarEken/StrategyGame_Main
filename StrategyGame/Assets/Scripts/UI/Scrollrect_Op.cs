using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scrollrect_Op : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public RectTransform parentObject;
    public RectTransform viewport;  

    public float thresholValue_top;
    public float thresholdValue_bot;

    public UnityEvent_float onBorderChanged;

    private Vector2 firstClickPosition;
    private Vector2 offsetVector;
    public void OnBeginDrag(PointerEventData eventData)
    {
        firstClickPosition = eventData.position;
        OnDrag(eventData);
    }

    private Vector2 changeVector;
    public void OnDrag(PointerEventData eventData)
    {
        //Görünüm posizyonunu değiştir
        changeVector = new Vector2(0f, eventData.position.y - firstClickPosition.y);
        Debug.Log(changeVector);
        firstClickPosition = eventData.position;

        if (!AbleToMove(changeVector))
            return;

        parentObject.anchoredPosition += changeVector;

        //Going Up
        if (changeVector.y < 0 && (parentObject.rect.height - parentObject.anchoredPosition.y) / parentObject.rect.height > thresholdValue_bot)
        {
            onBorderChanged.Invoke(1);
        }
        //Going Down
        else if(changeVector.y > 0 && (parentObject.rect.height - parentObject.anchoredPosition.y) / parentObject.rect.height < thresholdValue_bot)
        {
            onBorderChanged.Invoke(-1);
        }
    }

    private bool AbleToMove(Vector2 vector)
    {
        if (changeVector.y > 0 && parentObject.anchoredPosition.y > parentObject.rect.height - viewport.rect.height)   //Sonda ise hareketi engelle
            return false;
        else if (changeVector.y < 0 && parentObject.anchoredPosition.y <= 0f)    //Sonda ise hareketi engelle
            return false;

        return true;
    }

}
