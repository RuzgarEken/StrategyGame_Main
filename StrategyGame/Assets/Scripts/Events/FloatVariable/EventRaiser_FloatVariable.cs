using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventRaiser_FloatVariable : MonoBehaviour{
	[SerializeField]
	public UnityEvent_FloatVariable Event;

	public void Raise(FloatVariable item){
		this.Event.Invoke(item);
	}

}
	
