using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {

	private bool hasOpened;
	public Sprite openChestPotion;
	public Sprite openChest;
	public Sprite closedChest;
	public GameObject couragePotion;
	public Animator eyesEnemyChestAnimation;

	// Use this for initialization
	void Start () {
		hasOpened = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() { 
		//Debug.Log ("OOOOI");
		if(!hasOpened && tag != "ItemChest") {
			GetComponent <SpriteRenderer> ().sprite = openChestPotion;
			couragePotion.GetComponent<BoxCollider2D> ().enabled = true;
			//GetComponent<BoxCollider2D> ().enabled = false;
			hasOpened = true;
		}
	}

	public void CloseChest() {
		eyesEnemyChestAnimation.Stop ();
		GetComponent <SpriteRenderer> ().sprite = closedChest;
	}
}
