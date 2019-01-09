using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class GameEventListener_GameObject : GameEventListener<GameObject>{
		public GameEvent_GameObject Event;
		public UnityEvent_GameObject Response;

		protected override void OnEnable(){
			Event.RegisterListener(this);
		}

		protected override void OnDisable(){
			Event.UnregisterListener(this);
		}
		
		public override void OnEventRaised(GameObject item){
            Response.Invoke(item);
        }

    }


