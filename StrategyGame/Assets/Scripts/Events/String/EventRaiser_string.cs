using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser_string : MonoBehaviour{
	[SerializeField]
	public UnityEvent_string Event;

	public void Raise(string item){
		this.Event.Invoke(item);
	}

}



