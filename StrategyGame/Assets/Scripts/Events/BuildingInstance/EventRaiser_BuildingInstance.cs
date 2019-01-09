using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EventRaiser_BuildingInstance : MonoBehaviour{
		[SerializeField]
		public UnityEvent_BuildingInstance Event;

		public void Raise(Instance_Building item){
			this.Event.Invoke(item);
		}

	}
	
