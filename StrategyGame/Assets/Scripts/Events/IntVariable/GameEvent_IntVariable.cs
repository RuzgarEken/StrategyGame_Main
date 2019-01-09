using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/IntVariable")]
public class GameEvent_IntVariable : GameEvent<IntVariable>{

	public GameEvent_IntVariable(){
		listeners = new List<GameEventListener<IntVariable>>();
	}

	public override void Raise(IntVariable item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
	
}

