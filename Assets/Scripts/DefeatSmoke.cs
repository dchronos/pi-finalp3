using UnityEngine;
using System.Collections;

public class DefeatSmoke : MonoBehaviour {

	private bool animate;
	private Vector3 newFinalPosition;
	public GameObject blockedParticle;
	Vector3 enemyPosition;

	// Use this for initialization
	void Start () {
		animate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(animate) {
			Vector3 newPosition = new Vector3 (transform.position.x, 
				transform.position.y + 2, transform.position.z);
			
			float dist = newFinalPosition.y - transform.position.y;
			if (dist <= 0) {
				animate = false;
				GetComponent<Animator> ().enabled = false;
				transform.position = new Vector3 (0,0,0);
				Invoke ("BlockedEnemyParticleEmission", 0.2f);
			} else {
				transform.position = Vector3.Lerp (transform.position, newPosition, Time.deltaTime * 7.0f);
			}
		}
	}

	public void StartAnimation(Vector3 newPosition) {
		transform.position = newPosition;
		animate = true;
		newFinalPosition = new Vector3 (newPosition.x, newPosition.y + 6, newPosition.z);
		GetComponent<Animator> ().enabled = true;
		enemyPosition = newPosition;
	}

	public void BlockedEnemyParticleEmission() {
		//Vector3 newParticlePosition = new Vector3(charGirl.transform.position.x, 
			//particle.transform.position.y, particle.transform.position.z);
		blockedParticle.transform.position = enemyPosition;
		blockedParticle.GetComponent<ParticleSystem> ().Play ();
	}

}
