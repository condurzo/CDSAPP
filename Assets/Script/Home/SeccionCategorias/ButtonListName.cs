using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonListName : MonoBehaviour {
	public string NameButton;
	public string NamePadre;
	public static bool cambiarList;

	public void ButtonName(){
		NameButton = this.gameObject.GetComponentInChildren<Text> ().text;
		PlayerPrefs.SetString ("NombreTitulo", NameButton);
		NamePadre = transform.parent.name;

		switch (NamePadre) {
		case "List-1":
			PlayerPrefs.SetInt ("Lista", 2);
			PlayerPrefs.SetInt ("NumeroLista",1);
			cambiarList = true;
			break;
		case "List-2":
			PlayerPrefs.SetInt ("Lista", 3);
			cambiarList = true;
			break;
		case "List-3":
			PlayerPrefs.SetInt ("Lista", 4);
			cambiarList = true;
			break;

		}
	}
}
