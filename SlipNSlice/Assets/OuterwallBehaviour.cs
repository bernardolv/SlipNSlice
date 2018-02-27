using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterwallBehaviour : MonoBehaviour {
	GameObject myTile;
	GameObject tileobject;
	TileHandler tilescript;

	// Use this for initialization
	void Start () {
		tileobject = transform.parent.gameObject;
		tilescript = tileobject.GetComponent<TileHandler> ();
		if (tilescript.myTaker == null) {
			tilescript.isTaken = true;
			myTile = tileobject;
			tilescript.myTaker = this.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (tilescript.myTaker == null) {
			tilescript.isTaken = true;
			myTile = tileobject;
			tilescript.myTaker = this.gameObject;
		}
	}
}
