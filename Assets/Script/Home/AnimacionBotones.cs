using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimacionBotones : MonoBehaviour {

	public GameObject OfertasBtn;
	public GameObject CategoriasBtn;
	public GameObject ContactoBtn;
	public GameObject BarraBtn;
	public static bool activarBanner;
	public static string activeStatus; 

	void TodosGris(){
		OfertasBtn.GetComponent<Image> ().color = Color.grey;
		CategoriasBtn.GetComponent<Image> ().color = Color.grey;
		ContactoBtn.GetComponent<Image> ().color = Color.grey;
	}

	void Start (){
		activeStatus = "Ofertas";
	}

	public void OfertasCmd () {
		activeStatus = "Ofertas";
		activarBanner = false;
		TodosGris ();
		OfertasBtn.GetComponent<Image> ().color = Color.white;
		iTween.MoveTo (BarraBtn, iTween.Hash ("position", new Vector3 (29.7f, 271.7f, 34.4f), "time", .4f, "oncomplete",
			"setPosAndSpeed", "oncompletetarget", BarraBtn));
	}
	
	public void CategoriasCmd () {
		activeStatus = "Categorias";
		activarBanner = true;
		TodosGris ();
		CategoriasBtn.GetComponent<Image> ().color = Color.white;
		iTween.MoveTo (BarraBtn, iTween.Hash ("position", new Vector3 (88f, 271.7f, 34.4f), "time", .4f, "oncomplete",
			"setPosAndSpeed", "oncompletetarget", BarraBtn));
	}

	public void ContactoCmd () {
		activeStatus = "Contacto";
		activarBanner = true;
		TodosGris ();
		ContactoBtn.GetComponent<Image> ().color = Color.white;
		iTween.MoveTo (BarraBtn, iTween.Hash ("position", new Vector3 (146.6f, 271.7f, 34.4f), "time", .4f, "oncomplete",
			"setPosAndSpeed", "oncompletetarget", BarraBtn));
	}
		
}
