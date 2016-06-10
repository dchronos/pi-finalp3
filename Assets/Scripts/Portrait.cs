using UnityEngine;
using System.Collections;

public class Portrait : MonoBehaviour {

	public Enemy[] enemyVector;
	private bool hasRotated;
	private float finalAngle;
	private bool animating;

	// Use this for initialization
	void Start () {
		animating = false;
		finalAngle = 180;
		hasRotated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(animating) {
			Vector3 newRotation = new Vector3 (transform.rotation.x, 
			transform.rotation.y, transform.rotation.z - 6);
			GetComponent <Transform> ().Rotate(newRotation);
			GetComponent<Animator> ().enabled = true;

			if(GetComponent <Transform> ().localEulerAngles.z <= finalAngle) {
				animating = false;
			}
		}
	}

	void OnMouseDown() { 
		if(!hasRotated) {
			enemyVector[6].hasBeenAvoided = true;
			animating = true;
			hasRotated = true;
		}
	}
}
