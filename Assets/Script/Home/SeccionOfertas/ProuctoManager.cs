using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using LitJson;
using System;


public class ProuctoManager : MonoBehaviour {

	public GameObject Producto;
	public int spawneador;
	public Vector3 tempSuma;
	public int tempInicio;
	public RectTransform Contenedor;
	public Texture[] imagenesProductos;
	public Material mat;

	IEnumerator Start()
	{
		

		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/product/offers";
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null)
		{
			//Sucessfully loaded the JSON string
			Debug.Log("Loaded following JSON string" + www.data);

			//Process books found in JSON file
			ProcessOfertas(www.data);
		}
		else
		{
			Debug.Log("ERROR: " + www.error);
		}

	}

	//Converts a JSON string into Book objects and shows a book out of it on the screen
	private void ProcessOfertas(string jsonString)
	{
		JsonData jsonOfertas = JsonMapper.ToObject(jsonString);
		Ofertas ofertas;

		for(int i = 0; i<jsonOfertas["result"].Count; i++)
		{	
			ofertas = new Ofertas();
			ofertas.id = Convert.ToInt16(jsonOfertas["result"][i]["id"].ToString());
			//ofertas.type = jsonOfertas["result"][i]["type"].ToString();
			ofertas.name = jsonOfertas["result"][i]["name"].ToString();
			ofertas.image = jsonOfertas["result"][i]["image"].ToString();
			ofertas.price = jsonOfertas["result"][i]["price"].ToString();
			ofertas.order = Convert.ToInt16(jsonOfertas["result"][i]["order"].ToString());
			//			book.authors = new ArrayList();
			//
			//			for(int j = 0; j<jsonBooks["book"][i]["authors"]["author"].Count; j++)
			//			{
			//				book.authors.Add(jsonBooks["book"][i]["authors"]["author"][j]["name"].ToString());
			//			}

			imagenesProductos = new Texture [3]; //new Texture[Convert.ToInt16(ofertas.order)+1];
			spawneador = 3;//Convert.ToInt16(ofertas.order);//ofertas.id;
			Contenedor.sizeDelta = new Vector2 (0, Screen.height * spawneador);

			for (int ii = 0; ii < spawneador; ii++) {
				mat = Resources.Load("MaterialesProductos/Producto"+ii) as Material;
				mat.SetTexture ("_MainTex", imagenesProductos [ii]);
				Producto.GetComponent<Renderer>().material = mat;
				Producto.name = "HOLA"+ii;
				GameObject go = Instantiate (Producto) as GameObject;
				if (tempInicio == 0) {
					
					go.transform.position += new Vector3 (0, -50 ,- 5);
					go.transform.parent = gameObject.transform;

				} else {
					tempSuma -= go.transform.position;
					tempInicio++;
					go.transform.position += new Vector3 (0, -50 + tempSuma.y*1.9f, -5);
					go.transform.parent = gameObject.transform;
				}
				tempInicio++;
			}


			LoadOfertas(ofertas);
		}
	}

	//Finds book object in application and send the Book as parameter.
	//Currently only works with two books
	private void LoadOfertas(Ofertas ofertas)
	{
		GameObject bookGameObject = GameObject.Find ("HOLA"+ofertas.order.ToString()+"(Clone)");// + ofertas.id.ToString());
		bookGameObject.SendMessage("LoadOfertas", ofertas);
	}





//	void Start () {
//		
//		spawneador = 3;
//		Contenedor.sizeDelta = new Vector2 (0, Screen.height * spawneador);
//
//		for (int i = 0; i < spawneador; i++) {
//			mat = Resources.Load("MaterialesProductos/Producto"+i) as Material;
//			mat.SetTexture ("_MainTex", imagenesProductos [i]);
//			Producto.GetComponent<Renderer>().material = mat;
//			Producto.name = "HOLA";
//			GameObject go = Instantiate (Producto) as GameObject;
//			tempSuma -= go.transform.position;
//			go.transform.position += new Vector3 (0, tempSuma.y*2, -5);
//			go.transform.parent = gameObject.transform;
//
//			}
//		}


	}
