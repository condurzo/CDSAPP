using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using LitJson;
using System;

public class ListasJson : MonoBehaviour {

	Listas listas;

	public NewOfertasListas Lista1;
	public NewOfertasListas2 Lista2;
	public NewOfertasListas3 Lista3;
	public NewOfertasListas4 Lista4;

	IEnumerator Start(){
		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/list/all";
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null){
			//Sucessfully loaded the JSON string
			Debug.Log("Ofertas Lista 1" + www.data);

			//Process books found in JSON file
			ProcessListas(www.data);
		}else{
			Debug.Log("ERROR: " + www.error);
		}

	}


	private void ProcessListas(string jsonString){

		JsonData jsonLista = JsonMapper.ToObject(jsonString);

		for(int i = 0; i<jsonLista["result"].Count; i++){	

			listas = new Listas();
		
			listas.id1= jsonLista["result"][i]["one"].ToString();
			listas.id2 = jsonLista["result"][i]["two"].ToString();
			listas.id3 = jsonLista["result"][i]["three"].ToString();
			listas.id4 = jsonLista["result"][i]["four"].ToString();
	
			PlayerPrefs.SetString ("ListaId1", listas.id1);
			PlayerPrefs.SetString ("ListaId2", listas.id2);
			PlayerPrefs.SetString ("ListaId3", listas.id3);
			PlayerPrefs.SetString ("ListaId4", listas.id4);

//			Lista1.enabled = true;
//			Lista2.enabled = true;
//			Lista3.enabled = true;
//			Lista4.enabled = true;

		

		}
	}

	public float Contador;
	public float Contador2;
	public bool activador;
	public bool  activador2;
	public bool  activador3;
	void Update () {
		if (Contador <= 4.5f) {
			Contador += Time.deltaTime;
			if (Contador >= 4) {
				if (!activador) {
					StartCoroutine (Start ());
					activador = true;
					activador2 = true;
				}
			}
		}
		if (Contador2 <= 9f) {
			if (activador2) {
				Contador2 += Time.deltaTime;
				if (Contador2 >= 4) {
					StartCoroutine (Start ());
					activador2 = false;
					activador3 = true;
				}
			}
			if (activador3) {
				Contador2 += Time.deltaTime;
				if (Contador2 >= 8) {
					ManagerDescargas.ActivoListas = true;
				}
			}
		}
	}

}
