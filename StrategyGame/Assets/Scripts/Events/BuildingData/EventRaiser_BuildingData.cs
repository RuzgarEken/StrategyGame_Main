using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EventRaiser_BuildingData : MonoBehaviour{
		[SerializeField]
		public UnityEvent_BuildingData Event;

		public void Raise(BuildingData item){
			this.Event.Invoke(item);
		}

	}
	
