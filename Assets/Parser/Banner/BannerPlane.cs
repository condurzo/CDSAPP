using UnityEngine;
using System.Collections;
using UnityEngine.UI;

class BannerPlane : MonoBehaviour
{

	private Banner banner;


	//Is called by LoadXML as a SendMessage
	IEnumerator LoadBanner(Banner ban){
		this.banner = ban;

		//Create texture and load image
		Texture2D texture = new Texture2D(450, 100);
		WWW www = new WWW(ban.image);
		yield return www;

		//Apply image as a texture to this object
		www.LoadImageIntoTexture(texture);
		gameObject.GetComponent<Image>().overrideSprite = Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), new Vector2(0.5f,0.5f));

		//GetComponent<Renderer>().material.mainTexture = texture;



//		public void LoadImage(string nombre){
//			byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/"+nombre+".jpg");
//			Texture2D texture = new Texture2D (2, 2);
//			texture.LoadImage (bytes);
//			texture.filterMode = FilterMode.Trilinear;
//			Sprite sprite = Sprite.Create(texture, new Rect(0,0,texture.width, texture.height), new Vector2(0.5f,0.5f));
//			sprites.Add(sprite);
//		}


	}

//	//OnMouseDown, debug log the clicked book title
//	private void OnMouseDown()
//	{
//		if (banner != null)
//		{
//			Debug.Log("Clicked on book: " + banner.name);
//		}
//	}
//
}
