using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [Header("Right")]
    public UnityEngine.Events.UnityEvent E_RightClick;
    public UnityEngine.Events.UnityEvent E_RightDrag;
    public UnityEngine.Events.UnityEvent E_RightRelease;

    [Header("Left")]
    public UnityEngine.Events.UnityEvent E_LeftClick;
    public UnityEngine.Events.UnityEvent E_LeftDrag;
    public UnityEngine.Events.UnityEvent E_LeftRelease;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))   
        {
            E_LeftClick.Invoke();
        }
        else if (Input.GetMouseButton(0))
        {
            E_LeftDrag.Invoke();
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            E_LeftRelease.Invoke();
        }

        if (Input.GetMouseButtonDown(1))    
        {
            E_RightClick.Invoke();
        }
        else if (Input.GetMouseButton(1))
        {
            E_RightDrag.Invoke();
        }
        else if (Input.GetMouseButtonUp(1))
        {
            E_RightRelease.Invoke();
        }
    }
    
}
