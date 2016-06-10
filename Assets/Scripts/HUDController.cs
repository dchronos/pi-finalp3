using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDController : MonoBehaviour {

	public string[] currentImagesNames;
	public Sprite[] currentSprite;
	public GameObject[] fixedSlots;
	public Image slot01;
	public Image slot02;
	public Image slot03;
	public Image slot04;
	public Image slot05;

	public CharacterController character;
	public Text courageText;
	public Text potionsCount;
	public bool[] usedStorages;
	public int maxStorage;

	private bool animatingParticle;
	public GameObject particleRestore;
	public GameObject particleRestored;
	//public bool animatingFinishParticle;

	// Use this for initialization
	void Start () {
		//animatingFinishParticle = false;
		maxStorage = 5;
		usedStorages = new bool[maxStorage];
		currentImagesNames = new string[maxStorage];
		currentSprite = new Sprite[maxStorage];
		for(int i = 0; i < maxStorage; i++) {
			usedStorages [i] = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (animatingParticle) {
			GameObject charGirl = GameObject.Find ("Char");
			Vector3 newParticlePosition = new Vector3 (charGirl.transform.position.x, 
				                              particleRestore.transform.position.y, particleRestore.transform.position.z);
			particleRestore.transform.position = newParticlePosition;
		} else {
			GameObject charGirl = GameObject.Find ("Char");
			Vector3 newParticlePosition = new Vector3 (charGirl.transform.position.x, 
				particleRestored.transform.position.y, particleRestored.transform.position.z);
			particleRestored.transform.position = newParticlePosition;
		}

		bool aux = particleRestore.GetComponent<ParticleSystem> ().IsAlive();
		if (!aux) {
			ResetParticle ();
		}	
	}

	public void PointerClick() {
		if(character.collectedPotionsNum > 0 && character.stressLevel > 0) {
			if (gameObject.tag == "HUDPotion") {
				character.stressLevel -= 1;
				character.collectedPotionsNum -= 1;
				//couragePotions.collectedPotions -= 1;
				potionsCount.text = character.collectedPotionsNum.ToString();
					//couragePotions.collectedPotions.ToString ();
				courageText.text = character.stressLevel.ToString ();
				AnimateEnergyRestore ();
			}
		}
	}

	void AnimateEnergyRestore() {
		animatingParticle = true;
		particleRestore.SetActive (true);
		GameObject charGirl = GameObject.Find ("Char");
		Vector3 newParticlePosition = new Vector3(charGirl.transform.position.x, 
			particleRestore.transform.position.y, particleRestore.transform.position.z);
		particleRestore.transform.position = newParticlePosition;
		particleRestore.GetComponent<ParticleSystem> ().Play ();
		Invoke ("StopParticle", 2);
	}

	void StopParticle() {
		animatingParticle = false;
		particleRestore.SetActive (false);
		particleRestore.GetComponent<ParticleSystem> ().Stop ();

		GameObject charGirl = GameObject.Find ("Char");
		Vector3 newParticlePosition = new Vector3(charGirl.transform.position.x, 
			particleRestored.transform.position.y, particleRestored.transform.position.z);
		//animatingFinishParticle = true;
		particleRestored.transform.position = newParticlePosition;
		particleRestored.GetComponent<ParticleSystem> ().Play ();
	}

	void ResetParticle() {
		Vector3 newParticlePosition = new Vector3 (0, 
			particleRestore.transform.position.y, particleRestore.transform.position.z);
		particleRestore.transform.position = newParticlePosition;
		particleRestore.GetComponent<ParticleSystem> ().Play ();
	}
}
