using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/SoldierData")]
public class GameEvent_SoldierData : GameEvent<SoldierData>
{

	public GameEvent_SoldierData(){
		listeners = new List<GameEventListener<SoldierData>>();
	}

	public override void Raise(SoldierData item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
		
}
