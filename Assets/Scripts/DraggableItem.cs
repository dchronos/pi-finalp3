using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DraggableItem : MonoBehaviour {

	public GameObject defeatSmoke;
	public Enemy[] enemyVector;
	//public Sprite dragImage;
	Vector3 slotPosition;
	//public RectTransform slot01;
	private GameObject selectedObject;
	private HUDController HUD;
	public HUDController HUDGameObject;
	private GameObject fixedSlotGameObject;
	private int numOfSelectedSlot;
	private bool validMovement;
	private GameObject chest;
	private GameObject doorWithEnemy;
	private GameObject bookcase;
	public GameObject blockedEnemyParticle;

	// Use this for initialization
	void Start () {
		validMovement = false;
		HUD = HUDGameObject.GetComponent <HUDController>();
		doorWithEnemy = GameObject.Find ("DoorWithEnemy");
		chest = GameObject.Find ("ChestWithEnemy");
		bookcase = GameObject.Find ("MoveableBookcase");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Drag() {
		if(validMovement) {
			Debug.Log ("DRAG");
			transform.position = Input.mousePosition;
		}
	}

	public void BeginDrag() {
		Debug.Log ("BEGIN DRAG");

		for (int i = 0; i < HUD.maxStorage; i++) {
			string toFind = "slot" + i.ToString ();
			if(gameObject.tag == toFind) {
				if(HUD.currentSprite [i] != null) {
					validMovement = true;
					numOfSelectedSlot = i;
					fixedSlotGameObject = HUD.fixedSlots [i];
					GetComponent<Image>().sprite = HUD.currentSprite [i];
				}
			}
		}

		if(validMovement) {
			//GetComponent<Image>().sprite = dragImage;
			GetComponent<RectTransform> ().localScale = new Vector3 (
				GetComponent<RectTransform> ().localScale.x * 2, 
				GetComponent<RectTransform> ().localScale.y * 2,
				GetComponent<RectTransform> ().localScale.z);
			transform.position = Input.mousePosition;
		}
	}

	public void EndDrag() {

		if(validMovement) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero);

			Debug.Log ("Hit: " + hit);
			if (hit != null && hit.collider != null) {
				Debug.Log ("Hit tag: " + hit.collider.tag);
//				if (hit.collider.tag == "ItemWindow") {
//					enemyVector [2].hasBeenAvoided = true;
//					HUD.currentSprite [numOfSelectedSlot] = null;
//					HUD.currentImagesNames [numOfSelectedSlot] = null;
//					Destroy (gameObject);
//					validMovement = false;
//				} else 
				if (hit.collider.tag == "ItemVase" && HUD.currentImagesNames[numOfSelectedSlot] == "Anvil") {
					defeatSmoke.GetComponent<DefeatSmoke> ().StartAnimation (hit.collider.transform.position);
					enemyVector [1].hasBeenAvoided = true;
					//enemyVector [1].BlockedEnemyParticleEmission (1, blockedEnemyParticle);
					HUD.currentSprite [numOfSelectedSlot] = null;
					HUD.currentImagesNames [numOfSelectedSlot] = null;
				} else if (hit.collider.tag == "ItemFirePlace" && HUD.currentImagesNames[numOfSelectedSlot] == "CandleHolder") {
					enemyVector [2].hasBeenAvoided = true;
					//enemyVector [2].BlockedEnemyParticleEmission (1, blockedEnemyParticle);
					HUD.currentSprite [numOfSelectedSlot] = null;
					HUD.currentImagesNames [numOfSelectedSlot] = null;
				} else if (hit.collider.tag == "ItemBreakableShelf" && HUD.currentImagesNames[numOfSelectedSlot] == "BowlingBall") {
					enemyVector [4].hasBeenAvoided = true;
					//enemyVector [4].BlockedEnemyParticleEmission (1, blockedEnemyParticle);
					HUD.currentSprite [numOfSelectedSlot] = null;
					HUD.currentImagesNames [numOfSelectedSlot] = null;
				} else if (hit.collider.tag == "ItemChest" && HUD.currentImagesNames[numOfSelectedSlot] == "Padlock") {
					chest.GetComponent<Chest> ().CloseChest ();

					enemyVector [5].hasBeenAvoided = true;
					//enemyVector [5].BlockedEnemyParticleEmission (1, blockedEnemyParticle);
					HUD.currentSprite [numOfSelectedSlot] = null;
					HUD.currentImagesNames [numOfSelectedSlot] = null;
				} else if (hit.collider.tag == "ItemBookcase" && HUD.currentImagesNames[numOfSelectedSlot] == "Book") {
					bookcase.GetComponent<Bookcase> ().MoveBookcase ();
					Debug.Log ("COLIDIU");
					enemyVector [8].hasBeenAvoided = true;
					//enemyVector [8].BlockedEnemyParticleEmission (1, blockedEnemyParticle);
					HUD.currentSprite [numOfSelectedSlot] = null;
					HUD.currentImagesNames [numOfSelectedSlot] = null;
				} else if (hit.collider.tag == "ItemDoor" && HUD.currentImagesNames[numOfSelectedSlot] == "Wood" &&
							doorWithEnemy.GetComponent<Door> ().doorIsClosed) {
					doorWithEnemy.GetComponent<Door> ().LockDoor ();
					enemyVector [7].hasBeenAvoided = true;
					//enemyVector [7].BlockedEnemyParticleEmission (1, blockedEnemyParticle);
					HUD.currentSprite [numOfSelectedSlot] = null;
					HUD.currentImagesNames [numOfSelectedSlot] = null;
				} 

				transform.position = fixedSlotGameObject.GetComponent<RectTransform> ().position;
				GetComponent<RectTransform> ().localScale = fixedSlotGameObject.GetComponent<RectTransform> ().localScale;
				GetComponent<Image> ().sprite = null;
				validMovement = false;

				/*else {
//					//slotPosition = Camera.main.ScreenToWorldPoint (slot01.GetComponent<RectTransform> ().localScale);
//					slotPosition = Camera.main.ScreenToWorldPoint (fixedSlotGameObject.GetComponent<RectTransform> ().localScale);
//					transform.position = Vector3.Lerp (transform.position, slotPosition, Time.deltaTime * 4.0f);
//					validMovement = false;
					transform.position = fixedSlotGameObject.GetComponent<RectTransform> ().position;
					GetComponent<RectTransform> ().localScale = fixedSlotGameObject.GetComponent<RectTransform> ().localScale;
					validMovement = false;
				}*/
			} else {
				//transform.position = slot01.GetComponent<RectTransform> ().position;
				//GetComponent<RectTransform> ().localScale = slot01.GetComponent<RectTransform> ().localScale;
				transform.position = fixedSlotGameObject.GetComponent<RectTransform> ().position;
				GetComponent<RectTransform> ().localScale = fixedSlotGameObject.GetComponent<RectTransform> ().localScale;
				validMovement = false;
			}
		}
	}
}
