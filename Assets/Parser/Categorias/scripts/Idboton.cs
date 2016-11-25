using UnityEngine;
using System.Collections;

public class Idboton : MonoBehaviour {
	public int id;


	public void clickBtn(){
		Categoria cat = gameObject.GetComponent<Categoria> () as Categoria;
		cat.ActiveChildren ();
	}
}
