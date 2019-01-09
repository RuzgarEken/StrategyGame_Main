using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/Vector2")]
public class GameEvent_Vector2 : GameEvent<Vector2>
{

	public GameEvent_Vector2(){
		listeners = new List<GameEventListener<Vector2>>();
	}

	public override void Raise(Vector2 item){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}
		
}
