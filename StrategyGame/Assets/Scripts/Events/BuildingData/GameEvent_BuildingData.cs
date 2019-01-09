using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/BuildingData")]
public class GameEvent_BuildingData : GameEvent<BuildingData>
{

	public GameEvent_BuildingData(){
		listeners = new List<GameEventListener<BuildingData>>();
	}

	public override void Raise(BuildingData item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
		
}
