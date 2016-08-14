using UnityEngine;
using System.Collections;

public class Element {
	public string elementName;
	public ElementGroup elementGroup;
	public bool unlocked = false;
	public int id;

	public Element (string _elementName, ElementGroup _elementGroup, bool _unlocked, int _id) {
		elementName = _elementName;
		elementGroup = _elementGroup;
		unlocked = _unlocked;
		id = _id;
	} 
}
