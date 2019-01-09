using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/FloatVariable")]
public class GameEvent_FloatVariable : GameEvent<FloatVariable>{

	public GameEvent_FloatVariable(){
		listeners = new List<GameEventListener<FloatVariable>>();
	}

	public override void Raise(FloatVariable item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
	
}

