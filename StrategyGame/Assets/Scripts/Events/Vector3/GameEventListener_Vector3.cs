using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_Vector3 : GameEventListener<Vector3>
{
	public GameEvent_Vector3 Event;
	public UnityEvent_Vector3 Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}
		
	public override void OnEventRaised(Vector3 item)
    {
        Response.Invoke(item);
    }

}


