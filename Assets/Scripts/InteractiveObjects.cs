using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractiveObjects : MonoBehaviour {

	private GameObject currentGameObject;

	public string selectedObjectName;
	public Text scriptText;

	public HUDController HUD;
	public GameObject HUDGameObject;
	public GameObject item;
	//Vector3 originalPosition;
	GameObject posFinder;

	Vector3 newCarPos;

	Vector3 slotPosition;

	bool animating = false;

	// Use this for initialization
	void Start () {
		//HUD = new HUDController ();
		HUD = HUDGameObject.GetComponent <HUDController>();
		//originalPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);

			if (hit != null && hit.collider != null) {
				if(hit.collider.tag == "ItemWood") {
					animating = true;
				} else if(hit.collider.tag == "ItemCandleHolder") {
					currentGameObject = GameObject.Find ("CandleHolder");
					selectedObjectName = "CandleHolder";
					Debug.Log ("gameobject");
					animating = true;
				} else if(hit.collider.tag == "ItemAnvil") {
					currentGameObject = GameObject.Find ("Anvil");
					selectedObjectName = "Anvil";
					animating = true;
				} else if(hit.collider.tag == "ItemPadlock") {
					currentGameObject = GameObject.Find ("Padlock");
					Debug.Log ("clicou padlock");
					if(currentGameObject.GetComponent<BoxCollider2D> ().enabled) {
						Debug.Log ("ta enabled");
						selectedObjectName = "Padlock";
						animating = true;
					}
				} else if(hit.collider.tag == "ItemMorningStar") {
					currentGameObject = GameObject.Find ("MorningStar");
					selectedObjectName = "MorningStar";
					animating = true;
				} else if(hit.collider.tag == "ItemBowlingBall") {
					currentGameObject = GameObject.Find ("BowlingBall");
					selectedObjectName = "BowlingBall";
					animating = true;
				} else if(hit.collider.tag == "ItemBook") {
					currentGameObject = GameObject.Find ("Book");
					selectedObjectName = "Book";
					animating = true;
				}
			} 
		}

		if (animating && currentGameObject != null) {

			//slotPosition = Camera.main.ScreenToWorldPoint(slot01.transform.position);
			slotPosition = Camera.main.ScreenToWorldPoint(HUD.GetComponent<HUDController>().slot01.transform.position);
			currentGameObject.transform.position = Vector3.Lerp (currentGameObject.transform.position, slotPosition, Time.deltaTime * 4.0f);

			Vector3 newVector = new Vector3 (0.05f, 0.05f, 0.05f);
			currentGameObject.transform.localScale = Vector3.Lerp (currentGameObject.transform.localScale, newVector, Time.deltaTime * 2.0f);

			if(Vector3.Distance(transform.position, slotPosition) <= 1f) { //Se chegou na HUD
				int freeSlotId = -1;
				for(int i = 0; i < HUD.maxStorage; i++) {
					if(HUD.usedStorages[i] == false) {
						freeSlotId = i;
						HUD.usedStorages [i] = true;
						Debug.Log ("Adicinou no slot item chamado" + selectedObjectName);
						HUD.currentImagesNames [i] = selectedObjectName;
						HUD.currentSprite [i] = GetComponent<SpriteRenderer>().sprite;
						break;
					}
					//Debug.Log (i);
				}
				Debug.Log ("id");
				Debug.Log (freeSlotId);

				switch (freeSlotId) {
				case 0:
					HUD.GetComponent<HUDController>().slot01.sprite = GetComponent<SpriteRenderer>().sprite;
					break;
				case 1:
					HUD.GetComponent<HUDController>().slot02.sprite = GetComponent<SpriteRenderer>().sprite;
					break;
				case 2:
					HUD.GetComponent<HUDController>().slot03.sprite = GetComponent<SpriteRenderer>().sprite;
					break;
				case 3:
					HUD.GetComponent<HUDController>().slot04.sprite = GetComponent<SpriteRenderer>().sprite;
					break;
				case 4:
					HUD.GetComponent<HUDController>().slot05.sprite = GetComponent<SpriteRenderer>().sprite;
					break;
				}
				animating = false;
				Destroy(currentGameObject.gameObject);
			}
		}
	}
}
