using UnityEngine;
using System.Collections;

public class ScrollSolo : MonoBehaviour {
	
	public static int Pagina;
	public float contador;
	public static bool paso;
	public static bool inicio;
	public static bool avanzar;
	public static bool retrazar;

	void Update () {
		if (Pagina == 0) {
			//Debug.Log ("LALALA");
			inicio = false;
		}
		if (Pagina == 2) {
			inicio = true;
		}

		if (!paso) {
			contador += Time.deltaTime;
		}
		if (paso) {
			contador = 0;
		}

		if (contador >= 3) {
			if (!inicio) {
				avanzar = true;
				contador = 0;
			}
			if (inicio) {
				retrazar = true;
				contador = 0;
			}
		}


		//Debug.Log ("ES LA: " + Pagina);
	}
}
