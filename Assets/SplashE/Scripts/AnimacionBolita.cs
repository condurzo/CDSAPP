using UnityEngine;
using System.Collections;

public class AnimacionBolita : MonoBehaviour {

	private float smoothing = 1.0f;
	private Vector3 targetPosition;
	
	public float runSpeed ;
	private int jumpCount = 0;
	public float jumpForce ;
	
	public float gravity ;
	
	public Transform[] path;
	
	public float percentsPerSecond = 0.02f; // %2 of the path moved per second
	public static float currentPathPercent = 0.0f; //min 0, max 1
	
	
	// Use this for initialization
	void Start () {
		
		Physics.gravity = new Vector3(0, -gravity, 0);
		
	}
	
	// Update is called once per frame
	void Update () 
	{



		bool grounded;
		
		
		currentPathPercent += percentsPerSecond * Time.deltaTime;
		iTween.PutOnPath(gameObject, path, currentPathPercent);
		
		
		//JUMP//
		if (Physics.Raycast (transform.position, -transform.up, 1)) 
		{
			grounded = true;        
			//reset our jump count since we hit the ground //0 for double jump
			jumpCount = 1;   
			
		} 
		
		else 
		{
			grounded = false;
			float amtToMove = Input.GetAxisRaw ("Horizontal") * 0.1f * Time.deltaTime;     
		}
		
		
		if (Input.GetKeyDown ("space") && (grounded || jumpCount < 1)) 
		{
			GetComponent<Rigidbody>().AddRelativeForce (transform.up * jumpForce, ForceMode.Impulse);
		}
		
	}
	
	void OnDrawGizmos(){
		iTween.DrawPath(path);
	}
}
