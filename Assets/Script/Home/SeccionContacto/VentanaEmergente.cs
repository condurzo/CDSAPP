using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VentanaEmergente : MonoBehaviour {

	public InputField VaciarTexto1;
	public InputField VaciarTexto2;

	public void Limpiar(){
		VaciarTexto1.text = "";
		VaciarTexto2.text = "";
	}
}
