using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public void OnClick(){
		LoadJsonCategorias.instance.Back ();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			LoadJsonCategorias.instance.Back ();
		}
	}
}
