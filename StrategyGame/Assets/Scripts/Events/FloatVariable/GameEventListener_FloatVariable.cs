using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

    [System.Serializable]
    public class GameEventListener_FloatVariable : GameEventListener<FloatVariable>{
		public GameEvent_FloatVariable Event;
		public UnityEvent_FloatVariable Response;

		protected override void OnEnable(){
			Event.RegisterListener(this);
		}

		protected override void OnDisable(){
			Event.UnregisterListener(this);
		}

		public override void OnEventRaised(FloatVariable item){
            Response.Invoke(item);
        }

    }

