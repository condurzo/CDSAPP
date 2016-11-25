using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestScroll : MonoBehaviour {

	public static TestScroll instance;

	void Start(){
		instance = this;
	}

	public void SetScroll() {
		
		Invoke ("Scroll", 2f);
	}

	void Scroll(){
		GetComponent<ScrollRect>().verticalNormalizedPosition = 1;
	}
}
