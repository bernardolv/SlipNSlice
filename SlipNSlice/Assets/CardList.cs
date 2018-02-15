using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardList : MonoBehaviour {
	public static Dictionary<int, Card> carddic = new Dictionary<int, Card>();
	private static CardList instance = null;

	// Use this for initialization
	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
			return;
		}
		Destroy (this.gameObject);
	}

	void Start () {
		Card no1 = new Card(1, "WaterStarter", "Water", "Active1","Passive1", 10, 10); 


		carddic.Add(1, no1);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
