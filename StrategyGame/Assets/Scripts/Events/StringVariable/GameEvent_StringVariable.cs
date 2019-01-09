using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	[CreateAssetMenu(menuName = "IOUtils/Events/StringVariable")]
	public class GameEvent_StringVariable : GameEvent<StringVariable>{

		public GameEvent_StringVariable(){
			listeners = new List<GameEventListener<StringVariable>>();
		}

		public override void Raise(StringVariable item){
			for(int i=0;i<listeners.Count; i++)
				listeners[i].OnEventRaised(item);
		}
		
	}
