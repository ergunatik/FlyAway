using UnityEngine;
using System.Collections;

public class BaloonMove : MonoBehaviour {

	Rigidbody2D baloon;
	float speed = 1f;
	float x;
	private Vector2 endPos;
	private Vector2 startpos;
	private Quaternion startRot;
	private Quaternion endRot;
	private float degree = 0;

	// Use this for initialization
	void Start () {
		baloon = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		x = Input.GetAxis ("Horizontal");

		Quaternion startRot = transform.rotation;

		Vector2 startpos = transform.position;
		Vector2 endPos = startpos + new Vector2 (x,0);

		var localVel = endPos.x - startpos.x;

		if (localVel > -1 && localVel < 1) {
			degree = 0;
		}
		else if (localVel == -1) {
			degree = 30;
				}
		else if (localVel == 1 ){
			degree = -30;
		}
			

		Quaternion endRot = Quaternion.Euler (0, 0, degree);
		transform.position =  Vector2.Lerp (startpos, endPos, speed*Time.deltaTime);
		transform.rotation = Quaternion.Lerp (startRot,endRot , 3f*Time.deltaTime);



		if (Input.GetKeyDown (KeyCode.Space)) {
			baloon.velocity = new Vector2 (0, 3);
		}
	}
}
