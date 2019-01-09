using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Variables/FloatVariable")]
public class FloatVariable : Variable{

#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
#endif
	public float defaultValue;
	public float value;

	public FloatVariable(float value){
		this.value = value;
	}

    public override void SetDefault(){
		value = defaultValue;
    }

    public static implicit operator float(FloatVariable reference){
		return reference.value;
    }

	public static implicit operator FloatVariable(float value){
		return new FloatVariable(value);
    }

}
