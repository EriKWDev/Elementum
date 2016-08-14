using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour {

	public List<Recipe> recipes = new List<Recipe> ();
	public Dictionary<string, ElementGroup> elementGroups = new Dictionary<string, ElementGroup> ();
	public Dictionary<string, Element> elements = new Dictionary<string, Element> ();
	public List<Color> elementGroupColors = new List<Color> ();

	public Sprite defaultElementSprite;
	public Sprite defaultElementGroupSprite;
	public int id = 1;
	public TextMesh text;

	void Awake () {
		// AddElementGroup ("");
		// Element Groups...
		AddElementGroup ("Liquid Group");
		AddElementGroup ("Earth Group");
		AddElementGroup ("Fire Group");
		AddElementGroup ("Air Group");
		AddElementGroup ("Misc Group");
		AddElementGroup ("Nature Group");
		AddElementGroup ("Mighty Group");
		AddElementGroup ("Astronomical Group");
		AddElementGroup ("Living Entities");
		AddElementGroup ("Food Group");
		AddElementGroup ("Candy Group");
		AddElementGroup ("Vehicles");
		AddElementGroup ("Martin's Group");

		// AddElement ("", "", true);
		// Starting Elements
		AddElement ("Fire", "Fire Group", true);
		AddElement ("Earth", "Earth Group", true);
		AddElement ("Water", "Liquid Group", true);
		AddElement ("Air", "Air Group", true);

		// AddElement ("", "");
		// All other Elements...
		// Fire Group
		AddElement ("Lava", "Fire Group");
		AddElement ("Vulcano", "Fire Group");
		AddElement ("Explosion", "Fire Group");

		// Earth Group
		AddElement ("Dirt", "Earth Group");
		AddElement ("Dust", "Earth Group");
		AddElement ("Stone", "Earth Group");
		AddElement ("Ash", "Earth Group");
		AddElement ("Field", "Earth Group");
		AddElement ("Sand", "Earth Group");

		// Liquid Group
		AddElement ("Hot Water", "Liquid Group");
		AddElement ("Alcohol", "Liquid Group");
		AddElement ("Rain", "Liquid Group");
		AddElement ("Ocean", "Liquid Group");

		// Misc Group
		AddElement ("Nothing", "Misc Group");
		AddElement ("Vacuum", "Misc Group");
		AddElement ("Bubble", "Misc Group");
		AddElement ("Steam", "Misc Group");
		AddElement ("Happiness", "Misc Group");
		AddElement ("Vulcano Eruption", "Misc Group");
		AddElement ("Energy", "Misc Group");
		AddElement ("Life", "Misc Group");
		AddElement ("Light", "Misc Group");
		AddElement ("Sunlight", "Misc Group");
		AddElement ("Smile", "Misc Group");
		AddElement ("Chemicals", "Misc Group");
		AddElement ("Odor", "Misc Group");
		AddElement ("Wood", "Misc Group");
		AddElement ("Tools", "Misc Group");
		AddElement ("Weed", "Misc Group");

		// Nature Group
		AddElement ("Swamp", "Nature Group");
		AddElement ("Cloud", "Nature Group");
		AddElement ("Sky", "Nature Group");
		AddElement ("Rainbow", "Nature Group");
		AddElement ("Plant", "Nature Group");
		AddElement ("Tree", "Nature Group");
		AddElement ("Cocoa Beans", "Nature Group");
		AddElement ("Island", "Nature Group");

		//Food Group
		AddElement ("Wheat", "Food Group");
		AddElement ("Sugar", "Food Group");
		AddElement ("Cocoa", "Food Group");
		AddElement ("Hamburger", "Food Group");
		AddElement ("Brownie", "Food Group");
		AddElement ("Meat", "Food Group");
		AddElement ("Bread", "Food Group");

		// Mighty Group
		AddElement ("Unicorn", "Mighty Group");
		AddElement ("Cupcake", "Mighty Group");
		AddElement ("Chocolate", "Mighty Group");
		AddElement ("Chocolate Cupcake", "Mighty Group");

		// Astronomical Group
		AddElement ("Space", "Astronomical Group");
		AddElement ("Meteorite", "Astronomical Group");
		AddElement ("Comet", "Astronomical Group");
		AddElement ("Planet", "Astronomical Group");
		AddElement ("The Earth", "Astronomical Group");
		AddElement ("Sun", "Astronomical Group");
		AddElement ("Stars", "Astronomical Group");
		AddElement ("Black Hole", "Astronomical Group");

		// Living Entities
		AddElement ("Human", "Living Entities");
		AddElement ("Animal", "Living Entities");
		AddElement ("Horse", "Living Entities");
		AddElement ("Alien", "Living Entities");
		AddElement ("Bird", "Living Entities");
		AddElement ("Erik", "Living Entities");

		// Candy Group
		AddElement ("Candy", "Candy Group");
		AddElement ("Swedish Fish", "Candy Group");
		AddElement ("Sour Skulls", "Candy Group");
		AddElement ("Sugar UFO", "Candy Group");
		AddElement ("Lollipop", "Candy Group");

		//Vehicles
		AddElement ("Wheel", "Vehicles");
		AddElement ("Vaggon", "Vehicles");
		AddElement ("Bicycle", "Vehicles");
		AddElement ("Unicycle", "Vehicles");
		AddElement ("Car", "Vehicles");
		AddElement ("Train", "Vehicles");
		AddElement ("Airplane", "Vehicles");

		// Martin's Group
		AddElement ("Martin", "Martin's Group");
		AddElement ("Sneeze", "Martin's Group");
		AddElement ("Skalman", "Martin's Group");

		// AddRecipe ("", "", "");
		// Recipes
		AddRecipe ("Human", "Happiness", "Erik");
		AddRecipe ("Martin", "Tools", "Skalman");
		AddRecipe ("Human", "Tools", "Martin");
		AddRecipe ("Fire", "Air", "Nothing");
		AddRecipe ("Human", "Chemicals", "Alcohol");
		AddRecipe ("The Earth", "Animal", "Human");
		AddRecipe ("Chocolate", "Sugar", "Brownie");
		AddRecipe ("Animal", "Air", "Bird");
		AddRecipe ("Meat", "Bread", "Hamburger");
		AddRecipe ("Wheat", "Fire", "Bread");
		AddRecipe ("Animal", "Tools", "Meat");
		AddRecipe ("Rainbow", "Plant", "Weed");
		AddRecipe ("Human", "Weed", "Happiness");
		AddRecipe ("Human", "Rainbow", "Smile");
		AddRecipe ("Human", "Cupcake", "Smile");
		AddRecipe ("Life", "Space", "Alien");
		AddRecipe ("Energy", "Car", "Train");
		AddRecipe ("Air", "Train", "Airplane");
		AddRecipe ("Sand", "Ocean", "Island");
		AddRecipe ("Stone", "Tools", "Sand");
		AddRecipe ("Water", "Nothing", "Ocean");
		AddRecipe ("Tools", "Water", "Chemicals");
		AddRecipe ("Cocoa Beans", "Tools", "Cocoa");
		AddRecipe ("Tree", "Happiness", "Cocoa Beans");
		AddRecipe ("Cocoa", "Sugar", "Chocolate");
		AddRecipe ("Sun", "Explosion", "Black Hole");
		AddRecipe ("Sun", "Space", "Stars");
		AddRecipe ("Chocolate", "Cupcake", "Chocolate Cupcake");
		AddRecipe ("Bicycle", "Nothing", "Unicycle");
		AddRecipe ("Wheel", "Human", "Bicycle");
		AddRecipe ("Vaggon", "Energy", "Car");
		AddRecipe ("Wood", "Wheel", "Vaggon");
		AddRecipe ("Tools", "Wood", "Wheel");
		AddRecipe ("Wood", "Stone", "Tools");
		AddRecipe ("Tree", "Human", "Wood");
		AddRecipe ("Plant", "Water", "Tree");
		AddRecipe ("Martin", "Sugar", "Candy", "Swedish Fish", "Sour Skulls", "Sugar UFO", "Lollipop");
		AddRecipe ("Martin", "Water", "Sneeze");
		AddRecipe ("Chemicals", "Fire", "Explosion");
		AddRecipe ("The Earth", "Life", "Animal");
		AddRecipe ("Sugar", "Chemicals", "Candy");
		AddRecipe ("Happiness", "Sugar", "Cupcake");
		AddRecipe ("Sunlight", "Plant", "Sugar");
		AddRecipe ("Unicorn", "Rainbow", "Happiness");
		AddRecipe ("Cloud", "Water", "Rain");
		AddRecipe ("Sunlight", "Rain", "Rainbow");
		AddRecipe ("Horse", "Rainbow", "Unicorn");
		AddRecipe ("Wheat", "Animal", "Horse");
		AddRecipe ("Plant", "Field", "Wheat");
		AddRecipe ("Dirt", "Human", "Field");
		AddRecipe ("Dirt", "Sunlight", "Plant");
		AddRecipe ("Planet", "Lava", "Sun");
		AddRecipe ("Earth", "Planet", "The Earth");
		AddRecipe ("Meteorite", "Earth", "Planet");
		AddRecipe ("Air", "Nothing", "Vacuum");
		AddRecipe ("Space", "Stone", "Meteorite");
		AddRecipe ("Meteorite", "Fire", "Comet");
		AddRecipe ("Vacuum", "Sky", "Space");
		AddRecipe ("Cloud", "Air", "Sky");
		AddRecipe ("Planet", "Fire", "Sun");
		AddRecipe ("Sun", "Light", "Sunlight");
		AddRecipe ("Energy", "Fire", "Light");
		AddRecipe ("Bubble", "Swamp", "Odor");
		AddRecipe ("Vulcano", "Bubble", "Vulcano Eruption", "Explosion", "Energy");
		AddRecipe ("Lava", "Earth", "Vulcano");
		AddRecipe ("Fire", "Water", "Hot Water");
		AddRecipe ("Fire", "Hot Water", "Steam");
		AddRecipe ("Air", "Earth", "Dust");
		AddRecipe ("Steam", "Air", "Cloud");
		AddRecipe ("Fire", "Earth", "Lava");
		AddRecipe ("Air", "Water", "Bubble");
		AddRecipe ("Earth", "Water", "Dirt");
		AddRecipe ("Dirt", "Water", "Swamp");
		AddRecipe ("Fire", "Dust", "Ash");
		AddRecipe ("Swamp", "Sunlight", "Life");
		AddRecipe ("Lava", "Water", "Stone");

		// Instantiate everything
		int x = 0;
		foreach (KeyValuePair<string, ElementGroup> groupEntry in elementGroups) {
			int y = -1;
			GameObject elementGroupObject = new GameObject (groupEntry.Value.elementGroupName);
			elementGroupObject.AddComponent<ElementGroupBehaviour> ().elementGroup = groupEntry.Value;
			elementGroupObject.GetComponent <SpriteRenderer> ().sprite = defaultElementGroupSprite;
			elementGroupObject.transform.position = new Vector3 (x * 2f, 2f, 0f);
			elementGroupObject.tag = "ElementGroup";
			Instantiate (elementGroupObject);
			foreach (KeyValuePair<string, Element> elementEntry in groupEntry.Value.elements) {
				GameObject elementObject = new GameObject (elementEntry.Value.elementName);
				elementObject.AddComponent <ElementBehaviour> ().element = elementEntry.Value;
				elementObject.GetComponent <SpriteRenderer> ().sprite = defaultElementSprite;
				elementObject.tag = "Element";
				Instantiate (elementObject);
				elementObject.transform.SetParent (elementGroupObject.transform);
				elementObject.transform.localPosition = new Vector3 (0f, y * 1.8f, 0f);
				y--;
			}
			x++;
		}

		foreach (KeyValuePair<string, Element> entry in elements) {
			GameObject.Destroy (GameObject.Find (entry.Value.elementName + "(Clone)"));
		}

		foreach (KeyValuePair<string, ElementGroup> entry in elementGroups) {
			GameObject.Destroy (GameObject.Find (entry.Value.elementGroupName + "(Clone)"));
		}


		int tmp = 0;
		foreach (KeyValuePair<string, Element> entry in elements) {
			if (entry.Value.unlocked) {
				tmp++;
			}
		}

		text.text = (tmp + "/" + elements.Count + " Elements");
	}

	void Update () {
		ActivateElementsAndGroups ();
		if (Input.GetKeyDown (KeyCode.P)) {
			Cheat ();
		}
	}

	public void Cheat () {
		List<Element> fails = new List<Element> ();
		foreach (KeyValuePair<string, Element> entry1 in elements) {
			if (GetRecipe (entry1.Value).outcomes.Count == 0 && entry1.Value.unlocked == false) {
				fails.Add (entry1.Value);
			}
			foreach (KeyValuePair<string, Element> entry2 in elements) {
				Combine (entry1.Value, entry2.Value);
			}
		}

		string tmp = "";
		foreach (Element e in fails) {
			tmp += e.elementName + ", ";
		}
		print ("Fails: " + tmp);
	}

	public void ActivateElementsAndGroups () {
		foreach (GameObject o in GameObject.FindGameObjectsWithTag ("ElementGroup")) {
			bool unlocked = false;
			foreach (KeyValuePair<string, Element> entry in o.GetComponent<ElementGroupBehaviour> ().elementGroup.elements) {
				if (entry.Value.unlocked == true) {
					unlocked = true;
				}
			}
			o.GetComponent<Collider2D> ().enabled = unlocked;
			o.GetComponent<ElementGroupBehaviour> ().text.GetComponent<MeshRenderer> ().enabled = unlocked;
			o.GetComponent<ElementGroupBehaviour> ().enabled = unlocked;
			o.GetComponent<ElementGroupBehaviour> ().text.GetComponent<MeshRenderer> ().enabled = unlocked;
			o.GetComponent<SpriteRenderer> ().enabled = unlocked;
		}

		foreach (GameObject o in GameObject.FindGameObjectsWithTag ("Element")) {
			o.GetComponent<Collider2D> ().enabled = elements[o.name].unlocked;
			o.GetComponentInChildren<ElementBehaviour> ().text.GetComponent<MeshRenderer> ().enabled = elements[o.name].unlocked;
			o.GetComponent<ElementBehaviour> ().enabled = elements[o.name].unlocked;
			o.GetComponentInChildren<ElementBehaviour> ().text.GetComponent<MeshRenderer> ().enabled = elements[o.name].unlocked;
			o.GetComponent<SpriteRenderer> ().enabled = elements[o.name].unlocked;
			if (!elements[o.name].unlocked) o.transform.localPosition = new Vector3 (o.transform.localPosition.x, -15f, o.transform.localPosition.z);
		}
	}

	public void Combine (Element element1, Element element2) {
		List<Element> outcome = TryCombine (element1, element2);
		if (outcome.Count > 0) {
			foreach (Element _outcome in outcome) {
				_outcome.unlocked = true;
				elements [_outcome.elementName].unlocked = true;
			}

			int tmp = 0;
			foreach (KeyValuePair<string, Element> entry in elements) {
				if (entry.Value.unlocked) {
					tmp++;
				}
			}

			text.text = (tmp + "/" + elements.Count + " Elements");
		}
	}

	public List<Element> TryCombine (Element element1, Element element2) {
		List<Element> outcome = new List<Element> ();
		foreach (Recipe recipe in recipes) {
			if (recipe.workBothWays) {
				if ((recipe.element1 == element1 && recipe.element2 == element2) || (recipe.element1 == element2 && recipe.element2 == element1)) {
					outcome = recipe.outcomes;
				}
			} else {
				if (recipe.element1 == element1 && recipe.element2 == element2) {
					outcome = recipe.outcomes;
				}
			}
		}
		return outcome;
	}

	public List<Recipe> GetAllRecipies (Element element) {
		List<Recipe> allRecipes = new List<Recipe> ();

		Recipe recipe = GetRecipe (element);
		allRecipes.Add (recipe);

		if (GetRecipe (recipe.element1).element1 != null) {
			foreach (Recipe r in GetAllRecipies (recipe.element1)) {
				allRecipes.Add (r);
			}
		} 
		
		if (GetRecipe (recipe.element2).element2 != null) {
			foreach (Recipe r in GetAllRecipies (recipe.element2)) {
				allRecipes.Add (r);
			}
		}

		return allRecipes;
	}

	public Recipe GetRecipe (Element element) {
		Recipe tmp = new Recipe (null, null, true, new List<Element> ());
		foreach (Recipe recipe in recipes) {
			foreach (Element outcome in recipe.outcomes) {
				if (outcome == element) {
					tmp = recipe;
				}
			}
		}
		return tmp;
	}

	public Color CombineColors(params Color[] aColors) {
		Color result = new Color(0,0,0,0);
		foreach(Color c in aColors) {
			result += c;
		}
		result /= aColors.Length;
		return result;
	}

	public void AddRecipe (string element1, string element2, bool workBothWays, params string[] outcomes) {
		List<string> o = outcomes.ToList ();
		List<Element> _outcomes = new List<Element> ();
		foreach (string n in o) {
			_outcomes.Add (elements [n]);
		}
		recipes.Add (new Recipe (elements [element1], elements [element2], workBothWays, _outcomes));
	}

	public void AddRecipe (string element1, string element2, params string[] outcomes) {
		List<string> o = outcomes.ToList ();
		List<Element> _outcomes = new List<Element> ();
		foreach (string n in o) {
			_outcomes.Add (elements [n]);
		}
		recipes.Add (new Recipe (elements [element1], elements [element2], true, _outcomes));
	}

	public void AddElementGroup (string elementGroupName) {
		elementGroups.Add (elementGroupName, new ElementGroup (elementGroupName, elementGroupColors [elementGroups.Count]));
	}

	public void AddElementGroup (string elementGroupName, Color elementGroupColor) {
		elementGroups.Add (elementGroupName, new ElementGroup (elementGroupName, elementGroupColor));
	}

	public void AddElement (string elementName, string elementGroupName) {
		AddElement (elementName, elementGroups [elementGroupName], false);
	}

	public void AddElement (string elementName, string elementGroupName, bool unlocked) {
		AddElement (elementName, elementGroups [elementGroupName], unlocked);
	}

	public void AddElement (string elementName, ElementGroup elementGroup) {
		AddElement (elementName, elementGroup, false);
	}

	public void AddElement (string elementName, ElementGroup elementGroup, bool unlocked) {
		Element element = new Element (elementName, elementGroup, unlocked, id);

		elements.Add (elementName, element);
		elementGroup.elements.Add (elementName, element);
		id++;
	}
}