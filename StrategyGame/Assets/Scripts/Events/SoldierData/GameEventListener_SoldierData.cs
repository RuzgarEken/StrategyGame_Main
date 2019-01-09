using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_SoldierData : GameEventListener<SoldierData>
{
	public GameEvent_SoldierData Event;
	public UnityEvent_SoldierData Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}
		
	public override void OnEventRaised(SoldierData item)
{
        Response.Invoke(item);
    }

}


