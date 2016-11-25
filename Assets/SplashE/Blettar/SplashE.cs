using UnityEngine;
using System.Collections;

public class SplashE : MonoBehaviour {
	public float Tiempo;
	public AnimacionBolita bolita;
	public AudioClip sonido;
	public bool activeSonido;
	void Start(){
		
		GetComponent<AudioSource>().clip = sonido;
	
	}

	void Update () {
		if(AnimacionBolita.currentPathPercent>=1){
			bolita.enabled = false;
		}
		if( Tiempo >= 1.3f){
			if(!GetComponent<AudioSource>().isPlaying){
				GetComponent<AudioSource>().Play();
			}
		}

		Tiempo += Time.deltaTime;
		if( Tiempo >= 3.5f){
			System.GC.Collect();
			System.GC.WaitForPendingFinalizers();
			Resources.UnloadUnusedAssets();
			Application.LoadLevel("Splash");
		}
	}
}
