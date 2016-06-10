using UnityEngine;
using System.Collections;

public class FairyScript : MonoBehaviour {
	
	private Vector2 futurePoint;
	private Vector2 pastPoint;
	public GameObject girl;


	public GameObject startMarker;
	public GameObject endMarker;
	public float speed;
	private float startTime;
	private float journeyLength;
	private Rigidbody2D rig;
	private float sort = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, endMarker.transform.position, step);

		if (gameObject.transform.position.x == endMarker.transform.position.x) {
			Vector3 newVector = startMarker.transform.position;
			startMarker.transform.position = endMarker.transform.position;
			endMarker.transform.position = newVector;
			endMarker.transform.position = new Vector3(endMarker.transform.position.x, Random.Range(-3.0f, 3.0f), -1);
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = Random.Range(4,6);

		}


	}
}