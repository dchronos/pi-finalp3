using UnityEngine;
using System.Collections;

public class Carpet : MonoBehaviour {

	public Enemy[] enemyVector;
	public bool hasBeenMoved;
	public GameObject defeatSmoke;

	// Use this for initialization
	void Start () {
		hasBeenMoved = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() { 
		if(!hasBeenMoved) {
			GetComponent<Animator> ().enabled = true;
			enemyVector [9].hasBeenAvoided = true;
			enemyVector [9].GetComponent<SpriteRenderer> ().sortingOrder = -1;
			hasBeenMoved = true;
			defeatSmoke.GetComponent<DefeatSmoke> ().StartAnimation (enemyVector[9].transform.position);
		}
	}
}
