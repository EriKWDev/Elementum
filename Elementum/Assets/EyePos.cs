using UnityEngine;
using System.Collections;
using Tobii.EyeX.Framework;
using System.Collections.Generic;
using System.Linq;

public class EyePos : MonoBehaviour {

	 public GazePointDataMode gazePointDataMode = GazePointDataMode.LightlyFiltered;

    private EyeXHost _eyexHost;
    private IEyeXDataProvider<EyeXGazePoint> _dataProvider;
	public Vector3 pos;
	List<ElementBehaviour> selectedElements = new List<ElementBehaviour> ();

    /// <summary>
    /// Gets the last gaze point.
    /// </summary>
    public EyeXGazePoint LastGazePoint { get; private set; }

    protected void Awake()
    {
        _eyexHost = EyeXHost.GetInstance();
        _dataProvider = _eyexHost.GetGazePointDataProvider(gazePointDataMode);
    }

    protected void OnEnable()
    {
        _dataProvider.Start();
    }

    protected void OnDestroy()
    {
        _dataProvider.Stop();
    }

    protected void Update()
    {
        LastGazePoint = _dataProvider.Last;

		if (LastGazePoint.IsWithinScreenBounds) {
			pos = Camera.main.ScreenToWorldPoint (new Vector3 (LastGazePoint.Screen.x, LastGazePoint.Screen.y, 0f));
			pos.z = 0;
			transform.position = Vector3.Lerp (transform.position, pos, Time.deltaTime  * 3f);

			List<Collider2D> colliders = Physics2D.OverlapCircleAll (pos, 0.3f).ToList ();

			foreach (Collider2D c in colliders) {
				if (c != null) {
					if (c.GetComponent<ElementBehaviour> () != null) {
						c.GetComponent<ElementBehaviour> ().SendMessage ("OnEyeHover", SendMessageOptions.DontRequireReceiver);
						if (Input.GetKeyDown (KeyCode.LeftControl)) {
							c.GetComponent<ElementBehaviour> ().SendMessage ("OnEyeAndDrag", true, SendMessageOptions.DontRequireReceiver);
							if (!selectedElements.Contains (c.GetComponent<ElementBehaviour> ()))
								selectedElements.Add (c.GetComponent<ElementBehaviour> ());
						} 
					}
				}
			}

			if (Input.GetKeyDown (KeyCode.LeftAlt)) {
				if(selectedElements.Count > 1)
					GameObject.Find ("_GM").GetComponent<GameManager> ().Combine (selectedElements [0].element, selectedElements [1].element);

				foreach (ElementBehaviour e in selectedElements.ToList ()) {
					e.SendMessage ("OnEyeAndDrag", false, SendMessageOptions.DontRequireReceiver);
					selectedElements.Remove (e);
				}
			}
		}
    }
}
