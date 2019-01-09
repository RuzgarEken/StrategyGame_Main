using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/string")]
public class GameEvent_string : GameEvent<string>{

	public GameEvent_string(){
		listeners = new List<GameEventListener<string>>();
	}

	public override void Raise(string item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
	
}


