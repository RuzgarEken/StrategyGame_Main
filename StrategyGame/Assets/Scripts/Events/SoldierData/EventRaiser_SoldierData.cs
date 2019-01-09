using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser_SoldierData : MonoBehaviour{
	[SerializeField]
	public UnityEvent_SoldierData Event;

	public void Raise(SoldierData item){
		this.Event.Invoke(item);
	}

}
	
