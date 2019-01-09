using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_Vector2 : GameEventListener<Vector2>
{
	public GameEvent_Vector2 Event;
	public UnityEvent_Vector2 Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}
		
	public override void OnEventRaised(Vector2 item)
    {
        Response.Invoke(item);
    }

}


