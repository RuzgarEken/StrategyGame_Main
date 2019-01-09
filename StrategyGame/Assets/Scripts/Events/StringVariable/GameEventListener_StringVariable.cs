using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class GameEventListener_StringVariable : GameEventListener<StringVariable>{
		public GameEvent_StringVariable Event;
		public UnityEvent_StringVariable Response;

		protected override void OnEnable(){
			Event.RegisterListener(this);
		}

		protected override void OnDisable(){
			Event.UnregisterListener(this);
		}

		public override void OnEventRaised(StringVariable item){
            Response.Invoke(item);
        }

    }

