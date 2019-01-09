using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_BuildingData : GameEventListener<BuildingData>
{
	public GameEvent_BuildingData Event;
	public UnityEvent_BuildingData Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}
		
	public override void OnEventRaised(BuildingData item)
{
        Response.Invoke(item);
    }

}


