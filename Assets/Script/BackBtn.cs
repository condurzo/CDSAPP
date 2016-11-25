using UnityEngine;
using System.Collections;

public class BackBtn : MonoBehaviour {

	public GameObject BackBoton;
	public GameObject CartelSalir;

	void Update () {
		if ((!BackBoton.activeSelf)||(AnimacionBotones.activeStatus != "Categorias")) {
			if (Input.GetKeyDown (KeyCode.Escape)) {
				CartelSalir.SetActive (true);
			}
		}
	}

	public void SalirApp(){
		Application.Quit ();
	}
}
