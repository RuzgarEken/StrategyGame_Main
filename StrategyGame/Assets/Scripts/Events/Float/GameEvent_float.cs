using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/float")]
public class GameEvent_float : GameEvent<float>{

	public GameEvent_float(){
		listeners = new List<GameEventListener<float>>();
	}

	public override void Raise(float item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
	
}


