using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "IOUtils/Variables/IntVariable")]
public class IntVariable : Variable{

	#if UNITY_EDITOR
		[Multiline]
		public string DeveloperDescription = "";
	#endif
        [SerializeField]
		public IntVariable defaultValue;
		public int value;

		public IntVariable(int value){
			this.value = value;
		}

        public override void SetDefault(){
            value = defaultValue.value;
        }

        public static implicit operator int(IntVariable reference){
            return reference.value;
        }

        public static implicit operator IntVariable(int value){
            return new IntVariable(value);
        }
}
