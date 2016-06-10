using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

	private float normalSpeed = 2.0f;
	public float Speed;
	private Vector3 destination;

	void Start() {
		destination = this.transform.position;
		this.Speed = normalSpeed;
	}

	void Update() {
		destination.x += 1;
		transform.position = Vector3.MoveTowards (transform.position, destination, Speed * Time.deltaTime);
	}
}


