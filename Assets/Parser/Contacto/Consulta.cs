using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Consulta : MonoBehaviour {

	public InputField DetalleText;
	public InputField TelefonoText;

	public GameObject CartelOK;
	public GameObject CartelFail;
	public GameObject CartelFailConection;

	string consultaUrl = "http://158.69.197.37:8080/api/request/new";

	public void EnviarBtn(){
		if ((DetalleText.text == "") || (TelefonoText.text == "")) {
			CartelFail.SetActive (true);

		} else {
			StartCoroutine ("Enviar");
		} 

	}


	// Use this for initialization
	IEnumerator Enviar () {
		string fecha = DateTime.Now.ToString("dd/MM/yyyy");
		string hora = DateTime.Now.ToString("hh:mm:ss");
		string tempComentario;
		tempComentario = "Fecha: "+fecha+ " - Hora: "+hora+ " - Comentario: "+DetalleText.text;
			 
		// Create a form object for sending high score data to the server
		WWWForm form = new WWWForm();

		form.AddField( "phone", TelefonoText.text);
		form.AddField( "detail", tempComentario);

		// Create a download object
		WWW download = new WWW( consultaUrl, form );

		// Wait until the download is done
		yield return download;

		if(!string.IsNullOrEmpty(download.error)) {
			print( "Error downloading: " + download.error );
			CartelFailConection.SetActive (true);
		} else {
			// show the highscores
			Debug.Log(download.text);
			CartelOK.SetActive (true);
		}
	}
}
