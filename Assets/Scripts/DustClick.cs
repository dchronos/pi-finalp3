using UnityEngine;
using System.Collections;

public class DustClick : MonoBehaviour {
	
	public GameObject dustPrefab;

	RaycastHit hit;
	Ray ray;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

			if (hit != null && hit.collider != null) {
				Debug.Log(hit.transform.name);
			} else {
				GameObject dust = (GameObject)Instantiate (dustPrefab);
				Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				mousePos.z = 0;
				dust.transform.position = mousePos;
				Destroy (dust, 0.7f);
			}
		}
	}
}