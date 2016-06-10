using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDetector : MonoBehaviour {

	public Enemy[] enemyVector;
	public float Speed;
	private string toFind;
	private Vector3 destination;

	private bool allObjectsFound = false;
	private GameObject tempObject;
	private int currentObstacle = 0;
	private GameObject[] obstacles;

	private int num = 0;
	public float normalSpeed = 2.0f;
	private float minorSpeed = 0.7f;
	private float distanceToEnemyCollision = 25.0f;

	private float dist;
	private GameObject obstacle ;

	public cameraMovement camera;

	// Use this for initialization
	void Start () {

		while (!allObjectsFound) {
			toFind = "Obstacle" + num.ToString ();
			if (GameObject.Find (toFind) != null) {
				obstacle = GameObject.Find (toFind);
				num++;
			} else {
				allObjectsFound = true;
			}
		}
		obstacles = new GameObject[num];
		for (int i = 0; i < num; i++) {
			toFind = "Obstacle" + i.ToString ();
			tempObject = GameObject.Find (toFind);
			obstacles[i] = tempObject;
		}

		destination = this.transform.position;
		this.Speed = normalSpeed;
		Debug.Log (obstacles);
	}

	// Update is called once per frame
	void Update () {

		if (currentObstacle < num) {
			this.dist = obstacles[currentObstacle].transform.position.x - this.transform.position.x;
			//Debug.Log (this.dist);
			if (this.dist < distanceToEnemyCollision && this.dist > 0 && this.Speed >= 0.0f && !enemyVector[currentObstacle].hasBeenAvoided) {

				if(this.dist < 20) {
					this.Speed = normalSpeed;
					camera.Speed = normalSpeed;
				}
				if (this.Speed > minorSpeed) {
					this.Speed -= 0.05f;
					camera.Speed -= 0.05f;
				}
			} else if (enemyVector[currentObstacle].hasBeenAvoided) {
				Debug.Log ("MATOU");
				this.Speed = normalSpeed;
				camera.Speed = normalSpeed;
				currentObstacle++;
			} 
		} else {
			this.Speed = normalSpeed;
		}
		destination.x += 1;
		transform.position = Vector3.MoveTowards (transform.position, destination, Speed * Time.deltaTime);
	}
}
