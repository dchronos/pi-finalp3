using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {

	private float normalSpeed = 2.0f;
	public cameraMovement camera;
	public EnemyDetector enemyDetector;
	public Text stressLevelTxt;
	public int stressLevel;
	private float dist;
	private float distanceToEnemyCollision = 5.0f;
	public Enemy[] enemyVector;
	public int collectedPotionsNum;
	///public float xPosition;
	/// 

	private bool isGettingScared;

	// Use this for initialization
	void Start () {
		collectedPotionsNum = 3;
		isGettingScared = false;
		//xPosition = this.transform.position.x;
		stressLevel = 3;
	}
	
	// Update is called once per frame
	void Update () {

		//if(transform.position.x > 135) {
		//	Debug.Log ("ACABOU");
		//	Application.LoadLevel ("Menu");
		//}
		for(int i = 0; i < 8; i++) {
			if(!enemyVector[i].hasBeenAvoided) {

				this.dist = enemyVector[i].transform.position.x - this.transform.position.x;

				//Debug.Log ("dist: " + this.dist);
				if (this.dist < distanceToEnemyCollision && this.dist > 0 && !enemyVector[i].hasBeenAvoided && !isGettingScared) {
					if(!enemyVector[i].alreadyAttacked) {
						enemyVector [i].hasBeenAvoided = true;
						enemyVector [i].alreadyAttacked = true;
						enemyDetector.Speed = normalSpeed;
						camera.Speed = normalSpeed;
						Debug.Log ("BUU");
						enemyVector [i].GetComponent<SpriteRenderer>().sortingOrder = -1;
						stressLevel += 1;
						stressLevelTxt.text = stressLevel.ToString ();

						isGettingScared = true;
						Invoke ("CalmDown", 2);
					}
				} else if(isGettingScared) {
					enemyDetector.Speed = 0;
					enemyDetector.camera.Speed = 0;
				}
			}
		}


		//xPosition += 2f * Time.deltaTime;
		//Vector2 newPosition = new Vector3(xPosition, 0);
		//this.transform.position = newPosition;
	}

	void CalmDown() {
		isGettingScared = false;
		enemyDetector.Speed = enemyDetector.normalSpeed;
		enemyDetector.camera.Speed = enemyDetector.normalSpeed;
	}

}
