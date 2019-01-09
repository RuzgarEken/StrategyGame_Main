using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_Index : GameEventListener<Index>
{
	public GameEvent_Index Event;
	public UnityEvent_Index Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}
		
	public override void OnEventRaised(Index item)
    {
        Response.Invoke(item);
    }

}


