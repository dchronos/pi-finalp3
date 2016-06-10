using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Sprite openedDoor;
	public Sprite closedDoor;
	public Sprite lockedDoor;
	public bool doorIsClosed;

	// Use this for initialization
	void Start () {
		doorIsClosed = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() { 
		if (doorIsClosed) {
			GetComponent <SpriteRenderer> ().sprite = openedDoor;
			doorIsClosed = true;
		} else {
			GetComponent <SpriteRenderer> ().sprite = closedDoor;
			doorIsClosed = false;
		}
	}

	public void LockDoor(){
		GetComponent <SpriteRenderer> ().sprite = lockedDoor;
	}
}
