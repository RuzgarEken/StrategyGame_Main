using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser_float : MonoBehaviour{
	[SerializeField]
	public UnityEvent_float Event;

	public void Raise(float item){
		this.Event.Invoke(item);
	}

}



