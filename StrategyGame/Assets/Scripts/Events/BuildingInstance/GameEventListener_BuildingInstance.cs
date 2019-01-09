using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_BuildingInstance : GameEventListener<Instance_Building>
{
	public GameEvent_BuildingInstance Event;
	public UnityEvent_BuildingInstance Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}
		
	public override void OnEventRaised(Instance_Building item)
{
        Response.Invoke(item);
    }

}


