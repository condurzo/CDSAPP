using UnityEngine;
using LitJson;
using System;
using System.Collections;
using UnityEngine.UI;

public class LoadJsonBanner : MonoBehaviour
{
	public Image Banner0,Banner1,Banner2,Banner3,Banner4,Banner5;

	IEnumerator Start()
	{
		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/banner/all";
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null)
		{
			//Sucessfully loaded the JSON string
			Debug.Log("Banner" + www.data);

			//Process books found in JSON file
			ProcessBanner(www.data);
		}
		else
		{
			Debug.Log("ERROR: " + www.error);
		}

	}

	//Converts a JSON string into Book objects and shows a book out of it on the screen
	private void ProcessBanner(string jsonString)
	{
		JsonData jsonBanner = JsonMapper.ToObject(jsonString);
		Banner banner;

		for(int i = 0; i<jsonBanner["result"].Count; i++)
		{	
			banner = new Banner();
			banner.id = Convert.ToInt16(jsonBanner["result"][i]["id"].ToString());
			banner.name = jsonBanner["result"][i]["name"].ToString();
			banner.image = jsonBanner["result"][i]["image"].ToString();
			banner.order = Convert.ToInt16(jsonBanner["result"][i]["order"].ToString());
			LoadBanner(banner);
		}
	}

	//Finds book object in application and send the Book as parameter.
	//Currently only works with two books
	private void LoadBanner(Banner banner)
	{
		GameObject BannerGameObject = GameObject.Find ("ItemBanner"+ banner.order.ToString());// + ofertas.id.ToString());
		BannerGameObject.SendMessage("LoadBanner", banner);
	}
//	public float Contador;
//	public float Contador2;
//	public bool activador;
//	public bool  activador2;
//	void Update () {
//		if (Contador <= 8.5f) {
//			Contador += Time.deltaTime;
//			if (Contador >= 8) {
//				if (!activador) {
//					StartCoroutine (Start ());
//					activador = true;
//					activador2 = true;
//				}
//			}
//		}
//		if (activador2) {
//			if (Contador2 <= 17f) {
//				Contador2 += Time.deltaTime;
//				if (Contador2 >= 8) {
//					StartCoroutine (Start ());
//					activador2 = false;
//				}
//			}
//		}
//	}
}

