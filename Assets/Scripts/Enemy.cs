using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool alreadyAttacked;
	public bool hasBeenAvoided;

	// Use this for initialization
	void Start () {
		hasBeenAvoided = false;
		alreadyAttacked = false;
	}
	/*
	void OnMouseDown() {
		hasBeenAvoided = true;
		//gameObject.GetComponent<SpriteRenderer>().gameObject
		GetComponent<SpriteRenderer>().sortingOrder = -1;
		//transform.position = new Vector3(0, 0, 0);
		print ("oei");
	}
	*/
	// Update is called once per frame
	void Update () {
	}

	public void BlockedEnemyParticleEmission(int index, GameObject particle) {
		GameObject obstacle = GameObject.Find ("Obstacle" + index.ToString ());
		GameObject charGirl = GameObject.Find ("Char");
		Vector3 newParticlePosition = new Vector3(charGirl.transform.position.x, 
			particle.transform.position.y, particle.transform.position.z);
		particle.transform.position = newParticlePosition;
		particle.GetComponent<ParticleSystem> ().Play ();
	}
}
