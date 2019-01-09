using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/Index")]
public class GameEvent_Index : GameEvent<Index>
{

	public GameEvent_Index(){
		listeners = new List<GameEventListener<Index>>();
	}

	public override void Raise(Index item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
		
}
