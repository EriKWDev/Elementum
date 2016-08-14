using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElementGroup {

	public string elementGroupName;
	public Dictionary<string, Element> elements = new Dictionary<string, Element> ();
	public Color defaultGroupColor;
	public bool unlocked = false;

	public ElementGroup (string _elementGroupName, Color _defaultGroupColor) {
		elementGroupName = _elementGroupName;
		defaultGroupColor = _defaultGroupColor;
	}
}
