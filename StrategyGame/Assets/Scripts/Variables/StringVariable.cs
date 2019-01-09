using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Variables/StringVariable")][System.Serializable]
public class StringVariable : Variable {

	[SerializeField]
	public string defaultValue;

	[SerializeField]
	public string value;

	public StringVariable(string value){
		this.value = value;
	}

	public static implicit operator string(StringVariable reference){
		return reference.value;
    }

	public static implicit operator StringVariable(string value){
		return new StringVariable(value);
    }

    public override void SetDefault(){
        value = defaultValue;
    }

	public static bool EqualsByValue(StringVariable v1, StringVariable v2){
		return v1.value == v2.value;
	}
	
}
