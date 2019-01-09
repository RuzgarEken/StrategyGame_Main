using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRaiser_IntVariable : MonoBehaviour{
	[SerializeField]
	public UnityEvent_IntVariable Event;

	public void Raise(IntVariable item){
		this.Event.Invoke(item);
	}

}
	
