using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	public float ContadorSplash;

	void Update () {
		ContadorSplash += Time.deltaTime;
		if (ContadorSplash >= 3f) {
			Application.LoadLevel ("HomeNew");
		}
	}
}
