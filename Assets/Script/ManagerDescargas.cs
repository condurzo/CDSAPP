using UnityEngine;
using System.Collections;

public class ManagerDescargas : MonoBehaviour {
	
	public static bool ActivoLista;
	public static bool ActivoListas;

	public ListasJson ActivarListas;
	public NewOfertasListas ActivarLista1;
	public NewOfertasListas2 ActivarLista2;
	public NewOfertasListas3 ActivarLista3;
	public NewOfertasListas4 ActivarLista4;
	public LoadJsonCategorias ActivarCategorias;

	void Update () {
		if (ActivoLista) {
			ActivarListas.enabled = true;
			ActivoLista = false;
		}
		if (ActivoListas) {
			ActivarLista1.enabled = true;
			ActivarLista2.enabled = true;
			ActivarLista3.enabled = true;
			ActivarLista4.enabled = true;
			ActivarCategorias.enabled = true;
			ActivoListas = false;
		}

	
	}
		

}
