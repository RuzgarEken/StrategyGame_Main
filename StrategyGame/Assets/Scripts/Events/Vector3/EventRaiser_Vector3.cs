using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser_Vector3 : MonoBehaviour {
	[SerializeField]
	public UnityEvent_Vector3 Event;

	public void Raise(Vector3 item){
		this.Event.Invoke(item);
	}

}
	
