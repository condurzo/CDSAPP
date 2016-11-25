using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AddDescGO : MonoBehaviour {
	public GameObject DescripcionGO;
	public Button boton;
	public GameObject GoBoton;

	// Use this for initialization
	void Awake () {
		DescripcionGO = GameObject.Find ("DescNew");
	}
	void Start () {
		DescripcionGO = GameObject.Find ("DescNew");
		GoBoton = this.gameObject;
		boton = GoBoton.GetComponent<Button>();
		boton.onClick.AddListener(() => Test());
	}
	
	// Update is called once per frame
	void Test () {
		Debug.Log ("Probando");

		string nombreProducto = GoBoton.transform.FindChild ("TextName").GetComponent<Text> ().text;
		DescripcionGO.transform.FindChild ("NombreProdcuto").GetComponent<Text> ().text = nombreProducto;

		string nombreDetalle = GoBoton.transform.FindChild ("TextDesc").GetComponent<Text> ().text;
		DescripcionGO.transform.FindChild ("Descripcion").GetComponent<Text> ().text = nombreDetalle;

		string nombrePrecio = GoBoton.transform.FindChild ("TextPrice").GetComponent<Text> ().text;
		DescripcionGO.transform.FindChild ("Precios").GetComponent<Text> ().text = nombrePrecio;

		Sprite nombreImagen = GoBoton.transform.FindChild ("Image").GetComponent<Image> ().sprite;
		DescripcionGO.transform.FindChild ("ImagenProducto").GetComponent<Image> ().sprite = nombreImagen;


		DescripcionGO.GetComponent<CanvasGroup> ().alpha = 1;
		DescripcionGO.GetComponent<CanvasGroup> ().interactable = true;
		DescripcionGO.GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}
}
