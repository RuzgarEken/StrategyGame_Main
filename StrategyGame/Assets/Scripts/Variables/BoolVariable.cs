using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Variables/BoolVariable")][System.Serializable]
public class BoolVariable : Variable {

	[SerializeField]
	public bool value;

	public BoolVariable(bool value){
		this.value = value;
	}

	public static implicit operator bool(BoolVariable reference){
		return reference.value;
    }

	public static implicit operator BoolVariable(bool value){
		return new BoolVariable(value);
    }

	public static bool EqualsByValue(BoolVariable v1, BoolVariable v2){
		return v1.value == v2.value;
	}
	
}