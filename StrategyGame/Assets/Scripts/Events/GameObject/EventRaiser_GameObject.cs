using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class EventRaiser_GameObject : MonoBehaviour{
		[SerializeField]
		public UnityEvent_GameObject Event;

		public void Raise(GameObject item){
			this.Event.Invoke(item);
		}

	}
	
