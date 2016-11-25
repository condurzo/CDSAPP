using UnityEngine;
using System.Collections;

class OfertasPlane : MonoBehaviour{

	private Ofertas ofertas;

	//Is called by LoadXML as a SendMessage
	IEnumerator LoadOfertas(Ofertas ofer){
		this.ofertas = ofer;

		//Create texture and load image
		Texture2D texture = new Texture2D(500, 617);
		WWW www = new WWW(ofer.image);
		yield return www;

		//Apply image as a texture to this object
		www.LoadImageIntoTexture(texture);
		GetComponent<Renderer>().material.mainTexture = texture;
	}


}
