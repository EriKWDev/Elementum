 using UnityEngine;
 using System.Collections;
 
 public class Zoom : MonoBehaviour {
     
     public float zoomSpeed = 1f;
     public float targetOrtho;
     public float smoothSpeed = 2f;
     public float minOrtho = 1f;
     public float maxOrtho = 20f;
	 public float sensitivity = 1f;
	private float originalSensitivity;

	private Vector3 lastPosition;
     
     void Start() {
		originalSensitivity = sensitivity;
         targetOrtho = Camera.main.orthographicSize;
     }
     
     void Update () {
         float scroll = Input.GetAxis ("Mouse ScrollWheel");
         if (scroll != 0.0f) {
             targetOrtho -= scroll * zoomSpeed;
             targetOrtho = Mathf.Clamp (targetOrtho, minOrtho, maxOrtho);
         }
         
		Camera.main.orthographicSize = Mathf.Lerp (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
		sensitivity = originalSensitivity + targetOrtho / 5f;

		if (Input.GetMouseButtonDown (2)) {
			lastPosition = Input.mousePosition;
		}

		if (Input.GetMouseButton (2)) {
			Vector3 delta = Input.mousePosition - lastPosition;

			transform.position = Vector3.Lerp (transform.position, transform.position - delta, sensitivity * Time.deltaTime);
			lastPosition = Input.mousePosition;
		}
     }
 }