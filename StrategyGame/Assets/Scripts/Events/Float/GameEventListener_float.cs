using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_float : GameEventListener<float>{
	public GameEvent_float Event;
	public UnityEvent_float Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}

	public override void OnEventRaised(float item){
		Response.Invoke(item);
	}

}

