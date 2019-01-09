using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    [System.Serializable]
    public class GameEventListener_IntVariable : GameEventListener<IntVariable>{
		public GameEvent_IntVariable Event;
		public UnityEvent_IntVariable Response;

		protected override void OnEnable(){
			Event.RegisterListener(this);
		}

		protected override void OnDisable(){
			Event.UnregisterListener(this);
		}

		public override void OnEventRaised(IntVariable item){
            Response.Invoke(item);
        }

    }

