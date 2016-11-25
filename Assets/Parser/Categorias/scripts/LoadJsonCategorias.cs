using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using LitJson;
using System;

public class LoadJsonCategorias : MonoBehaviour {

	public List<Categoria> categoriaLista = new List<Categoria>();
	public List<Categoria> subcategoriaLista = new List<Categoria> ();

	public List<GameObject> botones = new List<GameObject> ();
	private Categoria root;
	public GameObject PrefabLista;
	public GameObject PrefabProducto;
	public GameObject ContenedorGO;

	//public Text NombreProdcuto;

	public Text textoSeccion;
	public GameObject backButton;
	public GameObject error;
	public GameObject cargando;
	private Categoria _currentCat;
	public Categoria currentCat



	{
		get{
			return _currentCat;
		}
		set{
			_currentCat=value;
			if (value == root) {
				backButton.SetActive (false);
			} else {
				backButton.SetActive (true);
			}
			textoSeccion.transform.parent.gameObject.SetActive (true);
			textoSeccion.text = value.nombre;
		}
	}

	public static LoadJsonCategorias instance;

	IEnumerator Start(){
		instance = this;
		backButton.SetActive (false);
		error.SetActive (false);
		cargando.SetActive (true);
		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/appliances/categories";
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null){
			//Sucessfully loaded the JSON string
			ProcessCategorias(www.text);
		}else{
			Debug.Log("ERROR: " + www.error);
			error.SetActive (true);
		}

	}

	private void ProcessCategorias(string jsonString){
		
		GameObject contCat = new GameObject ("contenedor categorias");
		JsonData jsonOfertas = JsonMapper.ToObject (jsonString);
		root = contCat.AddComponent<Categoria> () as Categoria;
		root.id = "0";
		root.nombre = "Categorias";
		currentCat = root;


		for (int i = 0; i < jsonOfertas ["result"].Count; i++) {	
			Categoria categoria = CreateButton ( jsonOfertas["result"][i],categoriaLista,true,true);
			categoria.parentCat = root;
			for (int j = 0; j < jsonOfertas ["result"] [i] ["subcategories"].Count; j++) {
				
				Categoria subcat = CreateButton (jsonOfertas ["result"] [i] ["subcategories"] [j] ,subcategoriaLista,true,false);
				subcat.parentCat = categoria;
				List<Categoria> applianceLista = new List<Categoria> ();
				for (int k = 0; k < jsonOfertas ["result"] [i] ["subcategories"] [j] ["appliances"].Count; k++) {
					
					Categoria appliance= CreateButton (jsonOfertas ["result"] [i] ["subcategories"] [j] ["appliances"] [k],applianceLista,true,false);
					appliance.parentCat = subcat;
				}
				subcat.subcategoria = applianceLista.ToArray ();
				applianceLista = new List<Categoria> ();

			}
			categoria.subcategoria = subcategoriaLista.ToArray ();
			subcategoriaLista = new List<Categoria> ();
		}
		root.subcategoria = categoriaLista.ToArray ();
		cargando.SetActive (false);
	}

	public Categoria CreateButton(JsonData element,List<Categoria> lista,bool isButton ,bool active,bool item=false ){
		GameObject go;
		if (!item) {
			go = Instantiate (PrefabLista) as GameObject;
		} else {
			go = Instantiate (PrefabProducto) as GameObject;
			LayoutElement lay = go.GetComponent<LayoutElement> ();
			lay.preferredHeight = Screen.height / 6;
		}
		string auxName = "";
		string auxID = "1";
		if (element != null) {
			auxName = element ["name"].ToString ();
			auxID = element ["id"].ToString ();

		}else{
			auxName = "No hay elementos disponibles a mostrar";
			auxID = "-1";
		}
		go.GetComponentInChildren<Text> ().text = auxName;

		if (isButton) {
			Idboton elIdBtn = go.GetComponent<Idboton> () as Idboton;
			elIdBtn.id = int.Parse (auxID);
		} else {
			Destroy (go.GetComponent<Idboton> ());
		}
		go.transform.SetParent( ContenedorGO.transform);
		go.transform.FindChild ("List");

		Categoria categoria = go.AddComponent<Categoria> () as Categoria;
		categoria.id = auxID;
		categoria.nombre = auxName;

		lista.Add (categoria);
		go.SetActive (active);
		return categoria;
	}

	public void Back(){
		if(currentCat!=null&& currentCat.parentCat!=null){
			currentCat.parentCat.ActiveChildren ();
		}
	}

	public void ResetCategorias(Categoria newCurrent){
		error.SetActive (false);
		Categoria[] cats=ContenedorGO.GetComponentsInChildren<Categoria> ();

		for (int a = 0; a < cats.Length; a++) {
			cats[a].gameObject.SetActive (false);
		}
		currentCat = newCurrent;
	}


}
