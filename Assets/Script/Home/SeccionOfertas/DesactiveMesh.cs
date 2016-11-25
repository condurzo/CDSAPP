using UnityEngine;
using System.Collections;

public class DesactiveMesh : MonoBehaviour {


	// Update is called once per frame
	public void Desactivar () {
		Renderer[] rs = GetComponentsInChildren<Renderer>();
		foreach(Renderer r in rs)
			r.enabled = false;
	}

	public void Activar () {
		Renderer[] rs = GetComponentsInChildren<Renderer>();
		foreach(Renderer r in rs)
			r.enabled = true;
	}
}
