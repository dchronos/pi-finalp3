using UnityEngine;
using System.Collections;

public class Bookcase : MonoBehaviour {

	public GameObject bookcaseEnemy;
	public bool hasBeenMoved;
	private Vector3 finalPosition;
	private bool animate;
	private bool shaking;
	private bool shakingLeft;

	// Use this for initialization
	void Start () {
		shakingLeft = true;
		animate = false;
		hasBeenMoved = false;
		finalPosition = new Vector3 (transform.position.x + 1.9f, 
			transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (animate) {
			
			Vector3 newPosition = new Vector3 (transform.position.x + 1, 
				                      transform.position.y, transform.position.z);

			float dist = finalPosition.x - transform.position.x;
			if (dist <= 0) {
				animate = false;
				shaking = true;
				bookcaseEnemy.GetComponent<Animator> ().enabled = true;
				Invoke ("StopShaking", 1);
			} else {
				transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime * 7.0f);
			}
		} 
	}

	public void MoveBookcase() {
		if(!hasBeenMoved) {
			hasBeenMoved = true;
			animate = true;
		}
	}

	void StopShaking() {
		bookcaseEnemy.GetComponent<Animator> ().enabled = false;
	}
}
