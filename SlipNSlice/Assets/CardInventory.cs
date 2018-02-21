using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour {
	//public static Dictionary<int, Card> cardinventory = new Dictionary<int, Card>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			for (int i = 1; i-1 < CardList.carddic.Count; i++) {
				Card mycard = CardList.carddic [i];
				Debug.Log (mycard.Name);
				//Debug.Log (CardList.carddic [i]);
			}
		}
	}
}
