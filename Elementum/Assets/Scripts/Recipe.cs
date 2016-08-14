using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recipe {
	public Element element1, element2;
	public bool workBothWays = true;
	public List<Element> outcomes = new List<Element> ();

	public Recipe (Element _element1, Element _element2, bool _workBothWays, Element _outcome) {
		element1 = _element1;
		element2 = _element2;
		outcomes.Add(_outcome);
		workBothWays = _workBothWays;
	}

	public Recipe (Element _element1, Element _element2, bool _workBothWays, List<Element> _outcomes) {
		element1 = _element1;
		element2 = _element2;
		foreach (Element element in _outcomes) {
			outcomes.Add (element);
		}
		workBothWays = _workBothWays;
	}
}
