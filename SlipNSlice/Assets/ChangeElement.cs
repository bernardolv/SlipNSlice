using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeElement : MonoBehaviour {
	string[] elements = new string[]{"Fire", "Water", "Grass", "Dark", "Light"};
	string myelement;
	SpriteRenderer myspriterenderer;
	Color mycolor;

	// Use this for initialization
	void Start () {
		myspriterenderer = GetComponent<SpriteRenderer> ();
		int index = Random.Range(0, elements.Length);
		myelement = elements[index];
		Debug.Log(myelement);
		AssignColor ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)){
			RemoveElement();
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			if (myelement == null) {
				AssignColor ();
			}
		}
	}

	public void AssignColor(){
		int index = Random.Range(0, elements.Length);
		myelement = elements[index];
		Debug.Log(myelement);
		if (myelement == "Fire") {
			myspriterenderer.color = new Color(173/255f,3/255f,3/255f,255/255f);
		}
		if (myelement == "Water") {
			myspriterenderer.color = new Color(41/255f,63/255f,206/255f,171/255f);
		}
		if (myelement == "Grass") {
			myspriterenderer.color = Color.green;
		}
		if (myelement == "Dark") {
			myspriterenderer.color = Color.black;
		}
		if (myelement == "Light") {
			myspriterenderer.color = new Color(1, .5f, 25 / 255f, 157 / 255f);
		}
	}
	public void RemoveElement(){
		myelement = null;
		myspriterenderer.color = new Color (1, 1, 1, .5f);
	}
}
