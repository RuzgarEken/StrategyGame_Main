using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameEventListener_string : GameEventListener<string>{
	public GameEvent_string Event;
	public UnityEvent_string Response;

	protected override void OnEnable(){
		Event.RegisterListener(this);
	}

	protected override void OnDisable(){
		Event.UnregisterListener(this);
	}

	public override void OnEventRaised(string item){
		Response.Invoke(item);
	}

}

