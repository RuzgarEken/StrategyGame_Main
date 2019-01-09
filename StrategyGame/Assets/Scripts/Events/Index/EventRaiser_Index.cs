using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser_Index : MonoBehaviour {
	[SerializeField]
	public UnityEvent_Index Event;

	public void Raise(Index item){
		this.Event.Invoke(item);
	}

}
	
