using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/Vector3")]
public class GameEvent_Vector3 : GameEvent<Vector3>
{

	public GameEvent_Vector3(){
		listeners = new List<GameEventListener<Vector3>>();
	}

	public override void Raise(Vector3 item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
		
}
