using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

	public Enemy[] enemyVector;
	public bool hasBeenMoved;
	private Vector3 finalPosition;
	private bool animate;
	public GameObject padlock;

	// Use this for initialization
	void Start () {
		animate = false;
		hasBeenMoved = false;
		finalPosition = new Vector3 (transform.position.x - 3, 
			transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (animate) {
			if (gameObject.tag == "ItemDroppableBarrel") {
				enemyVector [3].hasBeenAvoided = true;
			} else {
				Vector3 newPosition = new Vector3 (transform.position.x - 1, 
					                     transform.position.y, transform.position.z);

				float dist = transform.position.x - finalPosition.x;
				if (dist <= 0) {
					animate = false;
					padlock.GetComponent<BoxCollider2D> ().enabled = true;
				} else {
					transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime * 7.0f);
				}
			}
		}
	}

	void OnMouseDown() { 
		if(!hasBeenMoved) {
			hasBeenMoved = true;
			animate = true;
		}
	}

}
