using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EventRaiser_StringVariable : MonoBehaviour{
		[SerializeField]
		public UnityEvent_StringVariable Event;

		public void Raise(StringVariable item){
			this.Event.Invoke(item);
		}
	}
	
