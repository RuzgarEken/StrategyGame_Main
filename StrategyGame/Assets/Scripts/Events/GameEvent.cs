using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Events/GameEvent")]
public class GameEvent : ScriptableObject{

	private List<GameEventListener> listeners = new List<GameEventListener>();

	public void Raise(){
		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised();
	}

	public virtual void RegisterListener(GameEventListener listener){
		listeners.Add(listener);
	}

	public virtual  void UnregisterListener(GameEventListener listener){
		listeners.Remove(listener);	
	}

}


public class GameEvent<T> : ScriptableObject{

	protected List<GameEventListener<T>> listeners;

	public virtual void Raise(T item){

		for(int i=0;i<listeners.Count; i++)
			listeners[i].OnEventRaised(item);
	}

	public virtual void RegisterListener(GameEventListener<T> listener){
		listeners.Add(listener);
	}

	public virtual  void UnregisterListener(GameEventListener<T> listener){
		listeners.Remove(listener);	
	}

}


