using UnityEngine;
using System.Collections;

public class ChellangeControl : MonoBehaviour {

	public float scrollSpeed = 2.0f;
	public GameObject[] challenges;
	public GameObject[] chArrayleft;
	public GameObject[] chArrayright;
	public float frequency = 0.01f;
	float counter= 0.0f;
	public Transform challengeSpawnPoint;
	public Transform challengeSpawnPoint2;
	public Transform currentChallengeTransform;

	// Use this for initialization
	void Start () {
		//GenerateRandomChallenge ();
		chArrayleft = new GameObject[challenges.Length];
		chArrayright = new GameObject[challenges.Length];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Generating
			if (counter <= 0.0f) {
				GenerateRandomChallenge ();
			} else {
				counter -= Time.deltaTime * frequency;
			}


		//Scrolling
		GameObject currentChild;
		for (int i = 0; i < transform.childCount; i++) {
			currentChild = transform.GetChild (i).gameObject;
			ScrollChallenge (currentChild);
			currentChallengeTransform = currentChild.transform;
			//Debug.Log (currentChallengeTransform.position);
			if (currentChild.transform.position.y <= -7f) {
				Destroy (currentChild);
			}
		}
	

	}
	void ScrollChallenge (GameObject currentChallenge){
		currentChallenge.transform.position -= Vector3.up * (scrollSpeed * Time.deltaTime);
	}
	void GenerateRandomChallenge(){
		
		int arrayCounter1 = 0;
		int arrayCounter2 = 0;
		int platformRange1 = Random.Range (0, 4);
		int platformRange2 = 3 - platformRange1;
		Debug.Log ("platform 1= " + platformRange1);
		Debug.Log ("platform 2= "+ platformRange2);

		foreach (GameObject challenge in challenges) {
			string chName = challenge.name;
			if (challenge.tag == platformRange1.ToString() && chName.Contains("left")){
				chArrayleft [arrayCounter1] = challenge;
				++arrayCounter1;
			}
		}
		foreach (GameObject challenge in challenges) {
			string chName = challenge.name;
			if (challenge.tag == platformRange2.ToString() && chName.Contains("right")){
				chArrayright [arrayCounter2] = challenge;
				++arrayCounter2;
			}
		}

		//var challanges = GameObject.FindWithTag ("1");
		if (platformRange1 != 0) {
			GameObject newChallenge1 = Instantiate (chArrayleft [Random.Range (0, arrayCounter1)], challengeSpawnPoint.position, Quaternion.identity) as GameObject;
			newChallenge1.transform.parent = transform;
		}
		if (platformRange2 != 0) {
			GameObject newChallenge2 = Instantiate (chArrayright [Random.Range (0, arrayCounter2)], challengeSpawnPoint2.position, Quaternion.identity) as GameObject;
			newChallenge2.transform.parent = transform;
		}
		counter = 1.0f;
	}

}
