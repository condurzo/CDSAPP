using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using LitJson;
using System;


public class LoadJsonOfertas : MonoBehaviour {

	public GameObject Producto;
	public int spawneador;
	public Vector3 tempSuma;
	public int tempInicio;
	public RectTransform Contenedor;
	public GameObject ContenedorGO;
	public Texture[] imagenesProductos;
	public Material mat;
	public int tempCount;
	public int tempImagenes;
	public bool spawneo;
	Ofertas ofertas;


	IEnumerator Start(){

		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/product/offers";
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null){
			//Sucessfully loaded the JSON string
			Debug.Log("Ofertas" + www.data);

			//Process books found in JSON file
			ProcessOfertas(www.data);
		}else{
			Debug.Log("ERROR: " + www.error);
		}

	}



	//Converts a JSON string into Book objects and shows a book out of it on the screen
	private void ProcessOfertas(string jsonString){
		
		JsonData jsonOfertas = JsonMapper.ToObject(jsonString);

		for(int i = 0; i<jsonOfertas["result"].Count; i++){	
			tempCount = jsonOfertas ["result"].Count;

			ofertas = new Ofertas();
			ofertas.id = Convert.ToInt16(jsonOfertas["result"][i]["id"].ToString());
			ofertas.name = jsonOfertas["result"][i]["name"].ToString();
			ofertas.image = jsonOfertas["result"][i]["image"].ToString();
			ofertas.price = jsonOfertas["result"][i]["price"].ToString();
			ofertas.price1 = jsonOfertas["result"][i]["price1"].ToString();
			ofertas.price2 = jsonOfertas["result"][i]["price2"].ToString();
			ofertas.price3 = jsonOfertas["result"][i]["price3"].ToString();
			ofertas.order = Convert.ToInt16(jsonOfertas["result"][i]["order"].ToString());

			imagenesProductos = new Texture [tempCount]; 
			spawneador = tempCount;
			Contenedor.sizeDelta = new Vector2 (0, Screen.height * spawneador);
				
			for (int ii = 0; ii < spawneador; ii++) {
				mat = Resources.Load("MaterialesProductos/Producto"+ii) as Material;
				mat.SetTexture ("_MainTex", imagenesProductos [ii]);
				Producto.GetComponent<Renderer>().material = mat;
				Producto.name = "HOLA"+ii;
				GameObject go = Instantiate (Producto) as GameObject;
				go.transform.parent = ContenedorGO.transform;

				if (tempInicio == 0) {
					go.transform.position += new Vector3 (0, -50 ,- 5);
					go.transform.FindChild ("Contenedor");
				} else {
					tempSuma -= go.transform.position;
					tempInicio++;
					go.transform.position += new Vector3 (0, -50 + tempSuma.y*1.9f, -5);
					go.transform.FindChild ("Contenedor");
				}
				tempInicio++;
			}

			LoadOfertas(ofertas);

		}
	}


	private void LoadOfertas(Ofertas ofertas){
		GameObject bookGameObject = GameObject.Find ("HOLA"+ofertas.order.ToString()+"(Clone)");
		bookGameObject.SendMessage("LoadOfertas", ofertas);
	}


}
