using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/BuildingInstance")]
public class GameEvent_BuildingInstance : GameEvent<Instance_Building>
{

	public GameEvent_BuildingInstance(){
		listeners = new List<GameEventListener<Instance_Building>>();
	}

	public override void Raise(Instance_Building item)
    {
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
		
}
