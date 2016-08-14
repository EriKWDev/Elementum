using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Tobii.EyeX.Framework;

[RequireComponent (typeof (SpriteRenderer))]
[RequireComponent (typeof (BoxCollider2D))]
public class ElementBehaviour : MonoBehaviour {
	
	public Element element;

	public SpriteRenderer spriteRenderer;

	private bool dragging = false;
	private bool eyeDragging = false;
	private float distance;
	public Vector3 originalPos;
	public GameObject text;
	private GameManager gameManager;
	private Collider2D other;
	private bool toggled = false;
	public bool hover;
	private Vector3 originalScale;

	public EyeXGazePoint LastGazePoint { get; private set; }


	void Start () {
		originalScale = transform.localScale;
		gameManager = GameObject.Find ("_GM").GetComponent<GameManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.color = element.elementGroup.defaultGroupColor;

		GameObject textPrefab = GameObject.Find ("text");
		text = Instantiate (textPrefab);
		text.GetComponent<TextMesh> ().color = spriteRenderer.color;
		text.name = "Text";
		text.transform.SetParent (transform);
		text.GetComponent<TextMesh> ().text = element.elementName;
		text.transform.localPosition = new Vector3 (0f, 0.6f, 0f);
		originalPos = transform.localPosition;
	}

	void Update() {
		
		if (dragging) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 rayPoint = ray.GetPoint (distance);
			transform.position = Vector3.Lerp (transform.position, rayPoint, Time.deltaTime * 15f);
			spriteRenderer.sortingOrder = 200;

			other = Physics2D.OverlapCircle ((Vector2)transform.position, 1f);
		} else if (!eyeDragging) {
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, originalPos, Time.deltaTime * 15f);
			spriteRenderer.sortingOrder = 0;
		}

		LastGazePoint = GameObject.Find ("Eye").GetComponent<EyePos> ().LastGazePoint;
		if (eyeDragging) {
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (LastGazePoint.Screen.x, LastGazePoint.Screen.y, 1f));
			Vector3 rayPoint = ray.GetPoint (distance);
			rayPoint.z = 0f;
			transform.position = Vector3.Lerp (transform.position, rayPoint, Time.deltaTime * 15f);
			spriteRenderer.sortingOrder = 200;
		} else if (!dragging){
			transform.localPosition = Vector3.MoveTowards (transform.localPosition, originalPos, Time.deltaTime * 15f);
			spriteRenderer.sortingOrder = 0;
		}

		DrawLines ();
		if (hover) {
			DrawLines (true);
			transform.localScale = Vector3.Lerp (transform.localScale, originalScale + Vector3.one * 0.3f, Time.deltaTime * 3f);
		} else {
			DrawLines (false);
			transform.localScale = Vector3.Lerp (transform.localScale, originalScale, Time.deltaTime * 3f);
		}
		hover = false;
	}

	public void DrawLines () {
		if (toggled) {
			foreach (Recipe recipe in gameManager.GetAllRecipies (element)) {
				if (recipe.element1 != null && recipe.element2 != null && recipe.outcomes [0] != null) {
					ElementBehaviour o1, o2;
					List<ElementBehaviour> o3 = new List<ElementBehaviour> ();
					Vector3 p1, p2;

					o1 = GameObject.Find (recipe.element1.elementName).GetComponent<ElementBehaviour> ();
					o2 = GameObject.Find (recipe.element2.elementName).GetComponent<ElementBehaviour> ();
					foreach (Element e in recipe.outcomes) {
						o3.Add (GameObject.Find(e.elementName).GetComponent<ElementBehaviour> ());
					}

					p1 = o1.transform.position;
					p2 = o2.transform.position;

					Vector3 center = new Vector3 ((p1.x + p2.x) / 2, (p1.y + p2.y) / 2, p1.z);
					Color c = gameManager.CombineColors (o1.spriteRenderer.color, o2.spriteRenderer.color);

					Debug.DrawLine (p1, center, c);
					Debug.DrawLine (p2, center, c);
					foreach (ElementBehaviour e in o3) {
						Debug.DrawLine (e.transform.position, center, c);
					}
				}
			}
		}
	}
		
	public void DrawLines (bool toggle) {
		toggled = toggle;
	}

	void OnMouseExit () {
		DrawLines (false);
	}

	void OnMouseOver () {
		hover = true;
	}
 
    void OnMouseDown () {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp () {
		if (other.gameObject.GetComponent<ElementBehaviour> () != null && other.gameObject.GetComponent<Collider2D> () != this.GetComponent<Collider2D> ()) {
			gameManager.Combine (element, other.GetComponent<ElementBehaviour> ().element);
		}
        dragging = false;
    }

	void OnEyeHover () {
		hover = true;
	}

	void OnEyeAndDrag (bool clicking) {
		eyeDragging = clicking;
	}
}
