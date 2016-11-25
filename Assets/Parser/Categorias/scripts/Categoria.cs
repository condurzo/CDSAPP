using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;

public class Categoria : MonoBehaviour{
	public string id;
	public string nombre;
	public string descripcion;
	public string precio;
	public string titulo;
	public Categoria[] subcategoria;
	public Button boton;
	public GameObject GoBoton;
	public Categoria parentCat;
	public Categoria auxC;

	public GameObject Detalle;

	public Sprite auxP = new Sprite ();
	public void ActiveChildren(){
		LoadJsonCategorias.instance.ResetCategorias (this);

		if (subcategoria!=null) {
			for (int a = 0; a < subcategoria.Length; a++) {
				subcategoria [a].gameObject.SetActive (true);
			}
			TestScroll.instance.SetScroll ();
		} else {
			LoadJsonCategorias.instance.cargando.SetActive (true);
			LoadJsonCategorias.instance.textoSeccion.transform.parent.gameObject.SetActive (false);
			gameObject.SetActive (true);
			StartCoroutine (Load());
		}
	}

	void Start(){
		GoBoton = this.gameObject;
		boton = GoBoton.GetComponentInChildren<Button>();//VER ACA PARA ANALITYCS
		boton.onClick.AddListener(() => NameDetect());

		Detalle = GameObject.Find ("DescNew");
	}

	IEnumerator Load(){
		
		string url = "http://158.69.197.37:8080/api/product/byAppliance?applianceID="+id;
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null){
			//Sucessfully loaded the JSON string

			LoadJsonCategorias instance = LoadJsonCategorias.instance;
			JsonData jsonOfertas = JsonMapper.ToObject (www.text);
			List<Categoria> cat = new List<Categoria> ();

			if (jsonOfertas ["result"].Count == 0) {
				instance.CreateButton (null, cat, false, true, false);


			} else {

				for (int i = 0; i < jsonOfertas ["result"].Count; i++) {
					
					auxC = instance.CreateButton (jsonOfertas ["result"] [i], cat, false, true, true);

					nombre = auxC.transform.FindChild ("TextName").GetComponent<Text> ().text;
					//nombre = auxC.gameObject.GetComponentInChildren<Text> ().text;
					//Environment.NewLine + ingresa un salto de linea
					//auxC.gameObject.GetComponentInChildren<Text> ().text += "    " + "Precio 1: " + jsonOfertas ["result"] [i] ["price"] + "   ||   " + "Precio 2: " + jsonOfertas ["result"] [i] ["price2"]+ "   ||   " + "Precio 3: " + jsonOfertas ["result"] [i] ["price3"];

					Image auxM = auxC.transform.FindChild ("Image").GetComponent<Image> () as Image;
					StartCoroutine (loadImage (jsonOfertas ["result"] [i] ["image"].ToString (), auxM));


					descripcion = auxC.transform.FindChild ("TextDesc").GetComponent<Text> ().text;
					auxC.transform.FindChild ("TextDesc").GetComponent<Text> ().text = jsonOfertas ["result"] [i] ["description"].ToString ();


					precio = auxC.transform.FindChild ("TextPrice").GetComponent<Text> ().text;
					auxC.transform.FindChild ("TextPrice").GetComponent<Text> ().text += "Precio 1: " + jsonOfertas ["result"] [i] ["price"] + "   ||   " + "Precio 2: " + jsonOfertas ["result"] [i] ["price2"]+ "   ||   " + "Precio 3: " + jsonOfertas ["result"] [i] ["price3"];


				}
			}
			subcategoria = cat.ToArray ();
			LoadJsonCategorias.instance.cargando.SetActive (false);
		}else{
			Debug.Log("ERROR: " + www.error);
			LoadJsonCategorias.instance.error.SetActive (true);
		}
	}

	IEnumerator loadImage(string url,Image m){
		WWW www = new WWW(url);

		yield return www;


		auxP = Sprite.Create(www.texture,new Rect(0,0,www.texture.width,www.texture.height),Vector2.zero);
		m.sprite = auxP;
	}

	public void NameDetect(){
		AnalyticPropio.nombre = nombre;
		Debug.Log (nombre);
		AnalyticPropio.activo = true;

	}



}