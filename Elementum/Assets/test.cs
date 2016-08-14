using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	TextMesh textMesh;
	float value = 0.46f;
	float tmp;
	bool dragging = false;
	private float distance;

	void Start () {
		textMesh = GetComponent<TextMesh> ();
		tmp = value;
	}

	void Update () {
		if (Mathf.RoundToInt (Random.Range (0, 10)) == 0) {
			GetComponent<AudioSource> ().Play ();
			if (Random.Range (0, 10) == 0) {
				Noise ();
			}
		} else {
			GetComponent<AudioSource> ().Stop ();
			textMesh.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0f, 0f);
		}

		if (GetComponent<BoxCollider2D> () != null) {
			if (dragging) {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Vector3 rayPoint = ray.GetPoint (distance);
				transform.position = Vector3.Lerp (transform.position, rayPoint, Time.deltaTime * 15f);
			}
		}
	}

	void OnMouseDown() { 
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp() {
		dragging = false;
	}

	void Noise () {
		
		tmp -= Time.deltaTime * 5f;
		if (tmp <= -value) {
			tmp = value;
		}

		textMesh.GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (0f, tmp);
	}
}
