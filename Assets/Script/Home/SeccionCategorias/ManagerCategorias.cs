using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ManagerCategorias : MonoBehaviour {
	public GameObject Lista1;
	public GameObject Lista2;
	public GameObject Lista3;
	public GameObject Lista4Productos;
	public GameObject Titulo;
	public Sprite TituloSinBack;
	public Sprite TituloConBack;
	public string TituloString;

	public GameObject[] Listado2;
	public GameObject[] Listado3;

	void Start(){
		PlayerPrefs.SetInt ("Lista", 1);// ESTO VA EN EL SPLASH
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			BackTitulo ();
		}

		if (ButtonListName.cambiarList) {
			TituloString = PlayerPrefs.GetString ("NombreTitulo");
			Titulo.GetComponentInChildren<Text> ().text = TituloString;

			if (PlayerPrefs.GetInt ("Lista") == 1) {
				Lista2.SetActive (false);
				Lista1.SetActive (true);
				Titulo.GetComponent<Image> ().sprite = TituloSinBack;
				ButtonListName.cambiarList = false;
			}
			if (PlayerPrefs.GetInt ("Lista") == 2) {
				Lista1.SetActive (false);
				Lista2.SetActive (true);
				Titulo.GetComponent<Image> ().sprite = TituloConBack;
				PlayerPrefs.SetString ("ListaTitulo2", TituloString);
				ButtonListName.cambiarList = false;
			}
			if (PlayerPrefs.GetInt ("Lista") == 3) {
				Lista2.SetActive (false);
				Lista3.SetActive (true);
				Titulo.GetComponent<Image> ().sprite = TituloConBack;
				PlayerPrefs.SetString ("ListaTitulo3", TituloString);
				ButtonListName.cambiarList = false;
			}
			if (PlayerPrefs.GetInt ("Lista") == 4) {
				Lista3.SetActive (false);
				Lista4Productos.SetActive (true);
				Titulo.GetComponent<Image> ().sprite = TituloConBack;
				ButtonListName.cambiarList = false;
			}
		}




		switch(TituloString){
		//PRODUCTOS Seccion 2
		case "Electrodomesticos":
			RestoreList ();
			Listado2[0].GetComponentInChildren<Text> ().text = "TV Led y Video";
			Listado2[1].GetComponentInChildren<Text> ().text = "Ventilacion";
			Listado2[2].GetComponentInChildren<Text> ().text = "Lavado";
			Listado2[3].GetComponentInChildren<Text> ().text = "Cocinas";
			Listado2[4].GetComponentInChildren<Text> ().text = "Heladeras";
			break;
		case "Tecnologia":
			RestoreList ();
			Listado2[0].GetComponentInChildren<Text> ().text = "Informatica";
			Listado2[1].GetComponentInChildren<Text> ().text = "Celulares";
			Listado2[2].GetComponentInChildren<Text> ().text = "Audio";
			Listado2[3].GetComponentInChildren<Text> ().text = "Video Juegos";
			Listado2[4].GetComponentInChildren<Text> ().text = "Fotografia";
			break;
		case "Casa y Jardin":
			RestoreList ();
			Listado2[0].GetComponentInChildren<Text> ().text = "Muebles";
			Listado2[1].GetComponentInChildren<Text> ().text = "Cocina";
			Listado2[2].GetComponentInChildren<Text> ().text = "Baño";
			Listado2[3].GetComponentInChildren<Text> ().text = "Jardin";
			Listado2[4].GetComponentInChildren<Text> ().text = "Garage";
			break;
		case "Salud y Belleza":
			RestoreList ();
			Listado2[0].GetComponentInChildren<Text> ().text = "Cuidado Capilar";
			Listado2[1].GetComponentInChildren<Text> ().text = "Belleza y Cosmetica";
			Listado2[2].GetComponentInChildren<Text> ().text = "Baño e Higiene";
			Listado2[3].GetComponentInChildren<Text> ().text = "Bienestar";
			Listado2[4].GetComponentInChildren<Text> ().text = "Hombre";
			break;
		case "Bebes y Niños":
			RestoreList ();
			Listado2 [0].GetComponentInChildren<Text> ().text = "Juguetes";
			Listado2 [1].GetComponentInChildren<Text> ().text = "Juegos";
			Listado2 [2].GetComponentInChildren<Text> ().text = "Bebes";
			Listado2 [3].GetComponentInChildren<Text> ().text = "";
			Listado2 [3].GetComponent<Image> ().enabled = false;
			Listado2 [4].GetComponentInChildren<Text> ().text = "";
			Listado2 [4].GetComponent<Image> ().enabled = false;
			break;
		case "Deportes":
			RestoreList ();
			Listado2[0].GetComponentInChildren<Text> ().text = "Bicicletas";
			Listado2[1].GetComponentInChildren<Text> ().text = "Fitnes";
			Listado2[2].GetComponentInChildren<Text> ().text = "Rollers,Monopatines";
			Listado2[3].GetComponentInChildren<Text> ().text = "Camping";
			Listado2[4].GetComponentInChildren<Text> ().text = "";
			Listado2 [4].GetComponent<Image> ().enabled = false;
			break;
		case "Mas Categorias":
			RestoreList ();
			Listado2[0].GetComponentInChildren<Text> ().text = "Acces. Vehiculos";
			Listado2[1].GetComponentInChildren<Text> ().text = "Moda";
			Listado2[2].GetComponentInChildren<Text> ().text = "Bolsos,Equipaje";
			Listado2[3].GetComponentInChildren<Text> ().text = "Instrum. Musicales";
			Listado2[4].GetComponentInChildren<Text> ().text = "Sist.Seguridad";
			break;


			//PRODUCTOS Seccion 3
			//Electrodomesticos
		case "TV Led y Video":
			Listado3[0].GetComponentInChildren<Text> ().text = "TV Led";
			Listado3[1].GetComponentInChildren<Text> ().text = "Smart TV Led";
			break;
		case "Ventilacion":
			Listado3[0].GetComponentInChildren<Text> ().text = "Aires Acondicionados";
			Listado3[1].GetComponentInChildren<Text> ().text = "Ventiladores";
			break;
		case "Lavado":
			Listado3[0].GetComponentInChildren<Text> ().text = "Lavarropas";
			Listado3[1].GetComponentInChildren<Text> ().text = "Secarropas";
			break;
		case "Cocinas":
			Listado3[0].GetComponentInChildren<Text> ().text = "Cocinas";
			Listado3[1].GetComponentInChildren<Text> ().text = "Microondas";
			break;
		case "Heladeras":
			Listado3[0].GetComponentInChildren<Text> ().text = "Heladeras";
			Listado3[1].GetComponentInChildren<Text> ().text = "Freezers";
			break;

			//Tecnologia
		case "Informatica":
			Listado3[0].GetComponentInChildren<Text> ().text = "Notebooks";
			Listado3[1].GetComponentInChildren<Text> ().text = "Monitores";
			break;
		case "Celulares":
			Listado3[0].GetComponentInChildren<Text> ().text = "Celulares Libres";
			Listado3[1].GetComponentInChildren<Text> ().text = "Tablets";
			break;
		case "Audio":
			Listado3[0].GetComponentInChildren<Text> ().text = "Home Theatre";
			Listado3[1].GetComponentInChildren<Text> ().text = "Equipo de Musica";
			break;
		case "Video Juegos":
			Listado3[0].GetComponentInChildren<Text> ().text = "Juegos de Consolas";
			Listado3[1].GetComponentInChildren<Text> ().text = "Consolas";
			break;
		case "Fotografia":
			Listado3[0].GetComponentInChildren<Text> ().text = "Camaras Digitales";
			Listado3[1].GetComponentInChildren<Text> ().text = "Video Camaras";
			break;

			//Casa y Jardin
		case "Muebles":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Muebles para Cocina";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Muebles para Dormitorio";
			break;
		case "Cocina":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Vajilla";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Cubiertos";
			break;
		case "Baño":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Espejos";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Canastos";
			break;
		case "Jardin":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Parrilas";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Accesorios";
			break;
		case "Garage":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Hidrolavadoras";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Herramientas";
			break;

			//Salud y Belleza
		case "Cuidado Capilar":
			Listado3[0].GetComponentInChildren<Text> ().text = "Secadores";
			Listado3[1].GetComponentInChildren<Text> ().text = "Planchitas de Pelo";
			break;
		case "Baño e Higiene":
			Listado3[0].GetComponentInChildren<Text> ().text = "Balanza";
			Listado3[1].GetComponentInChildren<Text> ().text = "";
			Listado3 [1].GetComponent<Image> ().enabled = false;
			break;
		case "Belleza y Cosmetica":
			Listado3[0].GetComponentInChildren<Text> ().text = "Depiladoras";
			Listado3[1].GetComponentInChildren<Text> ().text = "";
			Listado3 [1].GetComponent<Image> ().enabled = false;
			break;
		case "Bienestar":
			Listado3[0].GetComponentInChildren<Text> ().text = "Tensiometro";
			Listado3[1].GetComponentInChildren<Text> ().text = "Nebulizador";
			break;
		case "Hombre":
			Listado3[0].GetComponentInChildren<Text> ().text = "Afeitadoras";
			Listado3[1].GetComponentInChildren<Text> ().text = "Cortadoras de Pelo";
			break;

			//Bebes y Niños
		case "Juguetes":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Niñas";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Niños";
			break;
		case "Juegos":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Piletas y Jardin";
			Listado3 [1].GetComponentInChildren<Text> ().text = "De Mesa";
			break;
		case "Bebes":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Cochecitos";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Cunas";
			break;

			//Deportes
		case "Bicicletas":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Mountain Bike";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Plegables";
			break;
		case "Fitnes":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Bicicletas Fijas";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Cintas para Correr";
			break;
		case "Rollers,Monopatines":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Rollers";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Monopatines";
			break;
		case "Camping":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Carpas";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Accesorios";
			break;

			//Mas Categorias
		case "Acces. Vehiculos":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Acees. Exterios";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Acces. Interior";
			break;
		case "Moda":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Relojes";
			Listado3 [1].GetComponentInChildren<Text> ().text = "";
			Listado3 [1].GetComponent<Image> ().enabled = false;
			break;
		case "Bolsos,Equipaje":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Bolsos";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Valijas";
			break;
		case "Instrum. Musicales":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Guitarras";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Teclados";
			break;
		case "Sist.Seguridad":
			Listado3 [0].GetComponentInChildren<Text> ().text = "Camaras";
			Listado3 [1].GetComponentInChildren<Text> ().text = "Alarmas";
			break;
		}

	}

	public void BackTitulo(){
		if (PlayerPrefs.GetInt ("Lista") == 2) {
			PlayerPrefs.SetInt ("Lista", 1);
			Titulo.GetComponent<Image> ().sprite = TituloSinBack;
			Titulo.GetComponentInChildren<Text> ().text = "Categorías";
			Lista2.SetActive (false);
			Lista1.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Lista") == 3) {
			PlayerPrefs.SetInt ("Lista", 2);
			Titulo.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("ListaTitulo2");;
			Lista3.SetActive (false);
			Lista2.SetActive (true);

		}
		if (PlayerPrefs.GetInt ("Lista") == 4) {
			PlayerPrefs.SetInt ("Lista", 3);
			Titulo.GetComponentInChildren<Text> ().text = PlayerPrefs.GetString ("ListaTitulo3");;
			Lista3.SetActive (true);
			Lista4Productos.SetActive (false);
		}
	}

	void RestoreList(){
		Listado2 [0].GetComponent<Image> ().enabled = true;
		Listado2 [1].GetComponent<Image> ().enabled = true;
		Listado2 [2].GetComponent<Image> ().enabled = true;
		Listado2 [3].GetComponent<Image> ().enabled = true;
		Listado2 [4].GetComponent<Image> ().enabled = true;
		Listado3 [0].GetComponent<Image> ().enabled = true;
		Listado3 [1].GetComponent<Image> ().enabled = true;
	}
}

