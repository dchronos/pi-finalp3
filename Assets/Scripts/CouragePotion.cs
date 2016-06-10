using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CouragePotion : MonoBehaviour {

	//public int collectedPotions;
	public CharacterController character;
	public GameObject potion;
	public GameObject chest;
	public Sprite emptyChest;
	public Text courageText;
	public SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
//		//collectedPotions = 0;
//		potion.GetComponent<ParticleSystem>().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() { 

		if(tag == "ItemChestPotion") {
			chest.GetComponent<SpriteRenderer> ().sprite = emptyChest;
		}

		character.collectedPotionsNum += 1;
		//collectedPotions += 1;

		potion.GetComponent<ParticleSystem>().Play();
		courageText.text = character.collectedPotionsNum.ToString ();

		Color color = new Color();
		color.a = 0.0f;

		renderer.color = color;
		Invoke ("DestroyPotion", 0.6f);

	}

	void DestroyPotion() {
		Destroy (potion);
	}
}
