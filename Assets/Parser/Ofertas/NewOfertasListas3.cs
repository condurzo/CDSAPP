using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using LitJson;
using System;


public class NewOfertasListas3 : MonoBehaviour {

	Ofertas ofertas;

	public string id;

	public GameObject[] auxC;

	public GameObject[] Detalle;


	IEnumerator Start(){
		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/product/byAppliance?applianceID="+PlayerPrefs.GetString("ListaId3");;
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null){
			//Sucessfully loaded the JSON string
			Debug.Log("Ofertas Lista 3" + www.data);

			//Process books found in JSON file
			ProcessOfertas(www.data);
		}else{
			Debug.Log("ERROR: " + www.error);
		}

	}


	private void ProcessOfertas(string jsonString){

		JsonData jsonOfertas = JsonMapper.ToObject(jsonString);

		for(int i = 0; i<jsonOfertas["result"].Count; i++){	
			
			ofertas = new Ofertas();
			ofertas.id = Convert.ToInt16(jsonOfertas["result"][i]["id"].ToString());
			ofertas.name = jsonOfertas["result"][i]["name"].ToString();
			ofertas.image = jsonOfertas["result"][i]["image"].ToString();
			ofertas.price = jsonOfertas["result"][i]["price"].ToString();
			ofertas.price1 = jsonOfertas["result"][i]["price1"].ToString();
			ofertas.price2 = jsonOfertas["result"][i]["price2"].ToString();
			ofertas.price3 = jsonOfertas["result"][i]["price3"].ToString();
			ofertas.descrip = jsonOfertas["result"][i]["description"].ToString();

			auxC [i].gameObject.SetActive (true);

			//PREVIEW
			Image auxM = auxC[i].transform.FindChild ("Image").GetComponent<Image> () as Image;
			StartCoroutine (loadImage (jsonOfertas ["result"] [i] ["image"].ToString (), auxM));

//			string nombre = auxC[i].transform.FindChild ("Nombre").GetComponent<Text> ().text;
//			auxC[i].transform.FindChild ("Nombre").GetComponent<Text> ().text += jsonOfertas ["result"] [i] ["name"];



			//DETALLE
			Image auxImgDet = Detalle [i].transform.FindChild ("ImagenProducto").GetComponent<Image> () as Image;
			StartCoroutine (loadImage (jsonOfertas ["result"] [i] ["image"].ToString (), auxImgDet));

			string nombreDetalle = Detalle[i].transform.FindChild ("NombreProdcuto").GetComponent<Text> ().text;
			Detalle[i].transform.FindChild ("NombreProdcuto").GetComponent<Text> ().text = jsonOfertas ["result"] [i] ["name"] +"";

			string tempPrecio = Detalle[i].transform.FindChild ("Precios").GetComponent<Text> ().text;
			Detalle[i].transform.FindChild ("Precios").GetComponent<Text> ().text += "Precio 1: " + jsonOfertas ["result"] [i] ["price"] + "   ||   " + "Precio 2: " + jsonOfertas ["result"] [i] ["price2"]+ "   ||   " + "Precio 3: " + jsonOfertas ["result"] [i] ["price3"];
			//"Precio 1: " + jsonOfertas ["result"] [i] ["price"] + "   ||   " + "Precio 2: " + jsonOfertas ["result"] [i] ["price2"]+ "   ||   " + "Precio 3: " + jsonOfertas ["result"] [i] ["price3"];

			string tempDescripcion = Detalle[i].transform.FindChild ("Descripcion").GetComponent<Text> ().text;
			Detalle[i].transform.FindChild ("Descripcion").GetComponent<Text> ().text = jsonOfertas ["result"] [i] ["description"]+"";

		}
	}

	IEnumerator loadImage(string url,Image m){
		WWW www = new WWW(url);

		yield return www;

		Sprite auxP= Sprite.Create(www.texture,new Rect(0,0,www.texture.width,www.texture.height),Vector2.zero);
		m.overrideSprite = auxP;
	}

	public float Contador;
	public float Contador2;
	public bool activador;
	public bool  activador2;
	void Update () {
		if (Contador <= 10.5f) {
			Contador += Time.deltaTime;
			if (Contador >= 10) {
				if (!activador) {
					StartCoroutine (Start ());
					activador = true;
					activador2 = true;
				}
			}
		}
		if (activador2) {
			if (Contador2 <= 11f) {
				Contador2 += Time.deltaTime;
				if (Contador2 >= 10) {
					StartCoroutine (Start ());
					activador2 = false;
				}
			}
		}
	}
}
