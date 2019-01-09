using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser_Vector2 : MonoBehaviour {
	[SerializeField]
	public UnityEvent_Vector2 Event;

	public void Raise(Vector2 item){
		this.Event.Invoke(item);
	}

}
	
