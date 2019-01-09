using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	[CreateAssetMenu(menuName = "IOUtils/Events/GameObject")]
	public class GameEvent_GameObject : GameEvent<GameObject>{

		public GameEvent_GameObject(){
			listeners = new List<GameEventListener<GameObject>>();
		}

		public override void Raise(GameObject item){
			for(int i=0;i<listeners.Count; i++)
				listeners[i].OnEventRaised(item);
		}
		
	}
