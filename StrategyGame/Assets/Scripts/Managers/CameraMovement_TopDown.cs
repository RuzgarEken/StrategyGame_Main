using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement_TopDown : MonoBehaviour
{
    [Header("Variables")]
    public PositionVariable cameraPosition;

    [Header("Events")]
    public GameEvent cameraOnMove;
    public GameEvent cameraStopMoving;

    void Awake(){
        firstClick = false;
        cameraPosition.value = Camera.main.transform.position;
    }

    void FixedUpdate(){
        MoveCamera();
    }

    Vector3 mouseOffset;
    Vector3 currentMousePos;
    bool firstClick;
    private void MoveCamera(){
         if(Input.GetMouseButtonDown(0)){
            firstClick = true;
            currentMousePos = Camera.main.WorldToViewportPoint(Input.mousePosition);
            mouseOffset =  currentMousePos - cameraPosition.value;
            cameraOnMove.Raise();
        }
        else if(Input.GetMouseButton(0) && firstClick){
            currentMousePos = Camera.main.WorldToViewportPoint(Input.mousePosition);

            if(currentMousePos + mouseOffset != cameraPosition.value)
                cameraPosition.value = currentMousePos + mouseOffset;
        }
        else if(Input.GetMouseButtonDown(0)){
            firstClick = false;
            cameraStopMoving.Raise();
        }
    }

}
