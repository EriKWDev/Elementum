using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (BoxCollider2D))]
public class ElementGroupBehaviour : MonoBehaviour {
	
	public ElementGroup elementGroup;

	public SpriteRenderer spriteRenderer;
	private bool dragging = false;
	private float distance;
	public GameObject text;

	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = elementGroup.defaultGroupColor;

		GameObject textPrefab = GameObject.Find ("text");
		text = Instantiate (textPrefab);
		text.GetComponent<TextMesh> ().color = spriteRenderer.color;
		text.name = "Text";
		text.transform.SetParent (transform);
		text.GetComponent<TextMesh> ().text = elementGroup.elementGroupName;
		text.transform.localPosition = new Vector3 (0f, 1f, 0f);

		GetComponent<BoxCollider2D> ().size = new Vector2 (1.6f, 1.6f);
	}

	void Update() {
		SortElements ();

		if (dragging) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			transform.position = Vector3.Lerp (transform.position, rayPoint, Time.deltaTime * 15f);
			spriteRenderer.sortingOrder = 1000;
		}
	}

	void SortElements () {
		List<ElementBehaviour> elements1 = new List<ElementBehaviour> ();
		List<ElementBehaviour> elements2 = new List<ElementBehaviour> ();
		elements1 =  GetComponentsInChildren<ElementBehaviour> ().ToList ();

		foreach (ElementBehaviour e in elements1) {
			if (e.element.unlocked) {
				elements2.Add (e);
			}
		}

		if (elements2.Count > 0) {
			elements2.Sort (delegate(ElementBehaviour a, ElementBehaviour b) {
				return (b.element.elementName).CompareTo (a.element.elementName);
			});
		}

		for (int i = 0; i < elements2.Count; i++) {
			elements2 [i].originalPos = new Vector3 (0f, -2f + (-i * 1.8f), elements2 [i].originalPos.z);
		}
	}

	void OnMouseDown() { 
		distance = Vector3.Distance(transform.position, Camera.main.transform.position);
		dragging = true;
	}

	void OnMouseUp() {
		dragging = false;
		spriteRenderer.sortingOrder = 0;
	}
}
