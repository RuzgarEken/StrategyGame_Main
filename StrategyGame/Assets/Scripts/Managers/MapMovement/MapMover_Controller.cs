using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapMover_Controller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Settings")]
    public Vector2 direction;
    public float necessaryInteractionTime;

    [Header("Events")]
    public UnityEvent_Vector2 E_MoveMap;
    public UnityEngine.Events.UnityEvent E_MovementStopped;

    float timer;
    bool mouseOver;
    public void OnPointerEnter(PointerEventData eventData)
    {
        timer = 0f;
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        E_MovementStopped.Invoke();
    }

    void FixedUpdate()
    {
        if (mouseOver)
            MoveMap();
    }

    private void MoveMap()
    {
        if (timer > necessaryInteractionTime)
            E_MoveMap.Invoke(direction);
        else
            timer += Time.deltaTime;
    }

}
