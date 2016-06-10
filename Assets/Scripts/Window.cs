using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

	public Enemy[] enemyVector;
	private int timesClicked;
	public Sprite windowClick01;
	public Sprite windowClick02;

	// Use this for initialization
	void Start () {
		timesClicked = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() { 
		if(timesClicked <= 1) {
			timesClicked++;
			Debug.Log ("clicou");
			if(timesClicked == 1) {
				GetComponent <SpriteRenderer> ().sprite = windowClick01;
			} else if(timesClicked == 2) {
				GetComponent <SpriteRenderer> ().sprite = windowClick02;
				enemyVector [0].hasBeenAvoided = true;
			}
		}
	}
}
