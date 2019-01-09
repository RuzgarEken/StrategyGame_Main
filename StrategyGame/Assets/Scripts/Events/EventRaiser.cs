using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;    

[System.Serializable]
public class EventRaiser : MonoBehaviour{
	public UnityEvent Event;

	public void Raise(){
		Event.Invoke();
	}

}

[System.Serializable]
public class EventRaiser<T> : MonoBehaviour{
	public UnityEvent<T> Event;

	public virtual void Raise(T item){
		Event.Invoke(item);
	}
}


